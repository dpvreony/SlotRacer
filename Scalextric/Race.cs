using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Scalextric
{
    public class Race
    {
        private int raceError;
        private bool firstCarFinnished = false;
        private int raceCompleteTime = 0;
        private Timer yFTimer;
        public static int instanceCount = 0;
        public RaceType RaceType { get; set; }
        public Car[] Cars { get; set; }
        public RaceStatus Status { get; private set; }
        public int LapsToRace { get; set; }
        public TimeSpan TimeToRace { get; set; }
        public TrackConnection Connection { get; private set; }
        public int SpeedAfterRace { get; set; }
        public YelloFlagSetting YellowFlagActSetting { get; set; }
        public bool YellowFlagEnabled { get; private set; }
        public int YellowFlagPower { get; set; }
        public int RaceTime
        {
            get
            {
                if (Status != RaceStatus.Complete)
                {
                    return Connection.RaceTime;
                }
                else
                {
                    return raceCompleteTime;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// sets default race type and sets event handlers for connection.
        /// </summary>
        /// <param name="conn"></param>
        public Race(TrackConnection conn)
        {
            instanceCount += 1;
            RaceType = RaceType.Practice;
            SpeedAfterRace = Properties.Settings.Default.SpeedAfterRace;
            YellowFlagPower = Properties.Settings.Default.YellowFlagSpeed;
            YellowFlagActSetting = YelloFlagSetting.StartButton;
            yFTimer = new Timer();
            yFTimer.AutoReset = false;
            yFTimer.Elapsed += yFTimer_Elapsed;
            Connection = conn;
            Connection.OnLapChanged += connection_OnLapChanged;
            Connection.OnConsoleButtonDown += connection_OnConsoleButtonDown;
            Connection.OnBrakePressed += Connection_OnBrakePressed;
        }

        /// <summary>
        /// Deconstructor
        /// Removes event handlers for connection
        /// </summary>
        ~Race()
        {
            Connection.OnLapChanged -= connection_OnLapChanged;
            Connection.OnConsoleButtonDown += connection_OnConsoleButtonDown;
            instanceCount -= 1;
        }

        /// <summary>
        /// Event handler for for button presses on the bower base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void connection_OnConsoleButtonDown(object sender, ConsoleButtonEventArgs e)
        {
            if (e.Button == ConsoleButton.Start)
            {
                if (!YellowFlagEnabled)
                {
                    SetYellowFlag();
                }
                else
                {
                    ClearYellowFlag();
                }
            }
        }

        /// <summary>
        /// Event handler for any brake button pressed on a controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Connection_OnBrakePressed(object sender, EventArgs e)
        {
            if (YellowFlagActSetting == YelloFlagSetting.BrakeButton && Status == RaceStatus.Started)
            {
                SetYellowFlag();
            }
        }

        /// <summary>
        /// Event handler for lap changes (occurs when a car crosses the start/finnish line
        /// Adds a laptime to the appropriate car.
        /// If a car has finished the race no laptime is added and on the last lap the RaceFinnished property is set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void connection_OnLapChanged(object sender, LapChangedEventArgs e)
        {
            if (Cars != null) // && e.LapInfo.CarId <= Cars.Length)
            {
                Car car = e.Car;
                if (!car.RaceComplete)
                {
                    car.AddLapTime(e.LapInfo.Time);
                    if (RaceType == RaceType.F1 && car.LapCount >= LapsToRace || firstCarFinnished)
                    {
                        car.RaceComplete = true;
                        SetCarPowerOverride();
                        firstCarFinnished = true;

                        bool raceComplete = true;
                        foreach (Car c in Cars)
                        {
                            if (c.LapCount > LapsToRace * 0.6 && !c.RaceComplete)
                            {
                                raceComplete = false;
                            }
                        }
                        if (raceComplete)
                        {
                            raceCompleteTime = (int)car.RaceTime;
                            Status = RaceStatus.Complete;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the yellow Flag delay timer
        /// </summary>
        public void SetYellowFlag()
        {
            int interval = Properties.Settings.Default.YellowFlagDelay;
            interval = (interval<10)? 10 : interval;
            yFTimer.Interval = interval;
            yFTimer.Start();
        }

        /// <summary>
        /// Runs when yellow flag delay timer has elapsed.
        /// This function sets the yellow flag for the race
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void yFTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            yFTimer.Stop();
            Connection.PauseTiming();
            YellowFlagEnabled = true;
            SetCarPowerOverride();
        }

        /// <summary>
        /// This function removes the yellow flag contition from the race and causes all cars to resume racing at normal speed
        /// </summary>
        public void ClearYellowFlag()
        {
            Connection.StartTiming();
            YellowFlagEnabled = false;
            SetCarPowerOverride();
        }

        /// <summary>
        /// Sets power override conditions for all cars at once
        /// </summary>
        private void SetCarPowerOverride()
        {
            List<int> carsToAdd = new List<int>();
            if (YellowFlagEnabled)
            {
                foreach (Car c in Cars)
                {
                    carsToAdd.Add(c.ID);
                }
                Connection.MaxPowerOverride(carsToAdd.ToArray(), YellowFlagPower);
            }
            else
            {
                foreach (Car c in Cars)
                {
                    if (c.RaceComplete)
                    {
                        carsToAdd.Add(c.ID);
                    }
                }
                Connection.MaxPowerOverride(carsToAdd.ToArray(), SpeedAfterRace);
            }
        }

        /// <summary>
        /// Returns an integer indicating how many laps have been completed
        /// Finds the car that has done the most laps and returns that lapcount
        /// </summary>
        /// <returns></returns>
        public int GetCompletedLaps()
        {
            int laps = 0;
            if (Cars != null)
            {
                foreach (Car c in Cars)
                {
                    if (c.LapCount > laps)
                    {
                        laps = c.LapCount;
                    }
                }
            }
            return laps;
        }

        /// <summary>
        /// Returns a list of the car ID's in the order they are currently placed in the race
        /// Sorts by lapcount (highest first) and then by RaceTime (lowest first)
        /// </summary>
        /// <returns></returns>
        public int[] GetPlaceOrder()
        {
            int[] order = new int[Cars.Length];
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = i;
            }

            bool restart = false;
            do
            {
                restart = false;
                for (int i = 0; i < Cars.Length - 1; i++)
                {
                    if (Cars[order[i]].LapCount < Cars[order[i + 1]].LapCount)
                    {
                        int a = order[i];
                        int b = order[i + 1];
                        order[i] = b;
                        order[i + 1] = a;
                        restart = true;
                    }
                    else if (Cars[order[i]].LapCount == Cars[order[i + 1]].LapCount)
                    {
                        if (Cars[order[i]].RaceTime > Cars[order[i + 1]].RaceTime)
                        {
                            int a = order[i];
                            int b = order[i + 1];
                            order[i] = b;
                            order[i + 1] = a;
                            restart = true;
                        }
                    }
                }
            } while (restart);

            return order;
        }

        /// <summary>
        /// Sets the race status to Started and starts the timing on the power base
        /// </summary>
        public void StartRace()
        {
            firstCarFinnished = false;
            Connection.StopTiming();
            Connection.StartTiming();
            Status = RaceStatus.Started;
            Car.Racing = true;
        }

        /// <summary>
        /// Sets the race status to Stopped and stops/resets the timing on the power base
        /// </summary>
        public void StopRace()
        {
            Connection.StopTiming();
            Connection.StartTiming();
            Connection.PauseTiming();
            Connection.ClearPowerOverride();
            Status = RaceStatus.Stopped;
            Car.Racing = false;
        }

        /// <summary>
        /// Sets the race status to Paused and pauses the timing on the power base
        /// </summary>
        //public void PauseRace()
        //{
        //    Connection.PauseTiming();
        //    Status = RaceStatus.Paused;
        //}

        /// <summary>
        /// This function removes all power from all cars to bring them to a halt.
        /// </summary>
        /// <param name="stopCars">Treue removes power and false restores normal power</param>
        public void StopAllCars(bool stopCars)
        {
            if (stopCars)
            {
                Connection.StopAllCars();
            }
            else
            {
                Connection.ClearPowerOverride();
            }
        }

    }
}

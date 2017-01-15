using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SlotRacer
{
    /// <summary>
    /// This class represents a Scalextric race
    /// It contains a Background worker that manages the comms between the track and this software and also a 
    /// TrackStatus property which holds all information of what is going on on the track
    /// </summary>
    public class Race
    {
        private static readonly int UPDATE_INTERVAL = 100;
        private static readonly int DEFAULT_RACE_LAPS = 20; 
        private static readonly int DEFAULT_ENDURANCE_TIME = 1000*60*5; // 5 Mins in ms
        private static readonly int COUNTDOWN_INTERVAL = 1000;
        private static readonly int COUNT_DOWN_VALUE = 5;
        private static readonly int DEFAULT_PRESTART_POWER = 0;

        private TrackStatus trackStatus;
        private BackGroundService bgs;
        private System.Timers.Timer updateTimer;
        private System.Timers.Timer countDownTimer;
        private List<int> carsInRace = new List<int>(); 
        
        /// <summary>
        /// A flag that indicates when the first car has completed the race (F1) or the teceTime has run out
        /// </summary>
        private bool raceComplete = false;

        public TrackStatus TrackStatus
        {
            get { return trackStatus; }
        }

        /// <summary>
        /// Get value indicating if the track is connected and ready
        /// </summary>
        public bool Connected
        {
            get { return bgs.Started; }
        }

        /// <summary>
        /// Get Race Start Countdown Value
        /// </summary>
        public int CountDown { get; private set; }

        /// <summary>
        /// Get Race time
        /// </summary>
        public TimeSpan RaceTime { get; private set; }

        /// <summary>
        /// Power override for the countdown time before a race starts;
        /// 100 to allow full power or 0 to stop cars from jumping the gun
        /// </summary>
        public int PreStartPower { get; set; }

        /// <summary>
        /// Get a sorted list of the IDs of the cars in the race.
        /// The list is sorted by race position. eg CarsInRace[0] is the ID of the leading car.
        /// </summary>
        public int[] CarsInRace
        {
            get { return carsInRace.ToArray(); }
        }

        /// <summary>
        /// Get/Set the type of race to start
        /// </summary>
        public RaceType RaceType { get; set; }

        /// <summary>
        /// Get/Set the number of laps to race (F1 Race)
        /// </summary>
        public int LapsToRace { get; set; }

        /// <summary>
        /// Get/Set the time of the race in ms(Enduro and Qualifying race)
        /// </summary>
        public Int64 EnduranceTime { get; set; }

        /// <summary>
        /// Get the lapcount of leading car
        /// </summary>
        public int LeadingLap { get; private set; }

        /// <summary>
        /// get the ID of the leading car
        /// </summary>
        public int LeadingCar { get; private set; }

        #region Events

        /// <summary>
        /// Event that occurs when the serial connection wit the track changes
        /// </summary>
        public event EventHandler OnConnectionChanged;
        public event EventHandler OnCountDownChanged;
        public event EventHandler OnRaceUpdate;

        #endregion

        /// <summary>
        /// Race constructor
        /// </summary>
        public Race()
        {
            trackStatus = new TrackStatus();
            trackStatus.LapChanged += TrackStatus_LapChanged;

            bgs = new BackGroundService(ref trackStatus);
            bgs.OnCommsError += bgs_OnCommsError;
            bgs.OnBackGroundServiceStopped += bgs_OnBackGroundServiceStopped;

            updateTimer = new System.Timers.Timer(UPDATE_INTERVAL);
            updateTimer.Elapsed += UpdateTimer_Elapsed;

            countDownTimer = new System.Timers.Timer(COUNTDOWN_INTERVAL);
            countDownTimer.Elapsed += CountDownTimer_Elapsed;

            RaceTime = new TimeSpan(0);
            RaceType = RaceType.Practice;
            LapsToRace = DEFAULT_RACE_LAPS;
            EnduranceTime = DEFAULT_ENDURANCE_TIME;
            PreStartPower = DEFAULT_PRESTART_POWER;
        }

        /// <summary>
        /// updateTimer elapsed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountDownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (CountDown > 0)
            {
                CountDown -= 1;
            }
            if (CountDown == 0)
            {
                raceComplete = false;
                TrackStatus.StartTiming();
                trackStatus.PowerOverride = -1;
                countDownTimer.Stop();
            }
            if (OnCountDownChanged != null)
            {
                RaiseEventOnUIThread( OnCountDownChanged,  e );
            }
        }

        /// <summary>
        /// updateTimer elapsed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //!Update Racetime from TrackStatus.TrackTime
            Int64 ms = TrackStatus.TrackTime;

            //!If this is a race with a countdown time, deduct the elapsed time from the initial time.
            if ((RaceType == RaceType.Endurance || RaceType == RaceType.Qualifying) && TrackStatus.RaceStatus != RaceStatus.Stopped)
            {
                ms = EnduranceTime - ms;
                if (ms <= 0)
                {
                    //! If the countdown has reached 0, set the time to 0 and flag race as complete.
                    raceComplete = true;
                    RaceTime = new TimeSpan(0);
                }
            }

            //! If the race is not complete, update the race time
            if (!raceComplete || TrackStatus.RaceStatus != RaceStatus.Cleared)
            {
                int hours = (int)(ms / (1000 * 60 * 60));
                ms -= hours * 60 * 60 * 1000;
                int mins = (int)(ms / (1000 * 60));
                ms -= mins * 60 * 1000;
                int secs = (int)(ms / 1000);
                ms -= secs * 1000;
                RaceTime = new TimeSpan(0, hours, mins, secs, (int)ms);
            }
        }

        /// <summary>
        /// Lapchanged event Handler.
        /// This function runs whenever a car completes a lap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackStatus_LapChanged(object sender, LapChangedEventArgs e)
        {
            if (e.Car.LapCount > LeadingLap)
            {
                //! if the current car's lapcount is higher than the last leading lap, increment the lapcount
                LeadingLap = e.Car.LapCount;
                LeadingCar = e.LapInfo.CarId;
                if (LeadingLap >= LapsToRace &&
                    RaceType == RaceType.F1 &&
                    TrackStatus.RaceStatus == RaceStatus.Started)
                {
                    //! If (in F1 Race) the lap count equals the number of laps to race, set raceComplete flag 
                    raceComplete = true;
                }
            }
            if (!carsInRace.Contains(e.LapInfo.CarId))
            {
                //! if a car crosses the line and is not part of the race, add him to the race.
                carsInRace.Add(e.LapInfo.CarId);
            }
            if (raceComplete)
            {
                //! if the race is complete, mark each car that crosses the line as having completed the race.
                e.Car.RaceComplete =true;
            }
            //! Sort the cars in race using the appropriare sorting procedure for the race type
            if (RaceType == RaceType.Qualifying)
            {
                SortRaceOrderQualifying();
            }
            else
            {
                SortRaceOrder();
            }
            if (CheckRaceOver())
            {
                StopRace();
            }
            if (OnRaceUpdate != null)
            {
                OnRaceUpdate.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Returns true if all the cars in the race have finished the race
        /// </summary>
        /// <returns></returns>
        private bool CheckRaceOver()
        {
            bool retVal = true;
            foreach(int c in carsInRace)
            {
                if (!TrackStatus.Cars[c-1].RaceComplete)
                {
                    retVal = false;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Sort CarsInRace from firs to last
        /// </summary>
        private void SortRaceOrder()
        {
            bool restart = false;
            do
            {
                restart = false;
                for (int i = 0; i < CarsInRace.Length-1; i++)
                {                    
                    if (trackStatus.Cars[carsInRace[i]-1].LapCount< trackStatus.Cars[carsInRace[i+1] - 1].LapCount ||
                        (trackStatus.Cars[carsInRace[i] - 1].LapCount == trackStatus.Cars[carsInRace[i + 1] - 1].LapCount &&
                        trackStatus.Cars[carsInRace[i] - 1].RaceTime > trackStatus.Cars[carsInRace[i + 1] - 1].RaceTime))
                    {
                        int tempCar = carsInRace[i];
                        carsInRace[i] = carsInRace[i + 1];
                        carsInRace[i + 1] = tempCar;
                        restart = true;
                    }
                }

            } while (restart);
        }
        
        /// <summary>
        /// Sort CarsInRace from firs to last
        /// </summary>
        private void SortRaceOrderQualifying()
        {
            bool restart = false;
            do
            {
                restart = false;
                for (int i = 0; i < CarsInRace.Length - 1; i++)
                {
                    if (trackStatus.Cars[carsInRace[i] - 1].FastestLap > trackStatus.Cars[carsInRace[i + 1] - 1].LapCount)
                    {
                        int tempCar = carsInRace[i];
                        carsInRace[i] = carsInRace[i + 1];
                        carsInRace[i + 1] = tempCar;
                        restart = true;
                    }
                }

            } while (restart);
        }

        /// <summary>
        /// Start a race
        /// </summary>
        public void StartRace()
        {
            TrackStatus.ResetTiming();
            if (RaceType != RaceType.Practice && RaceType != RaceType.Qualifying)
            {
                CountDown = COUNT_DOWN_VALUE + 1;
                //Count Down
                countDownTimer.Start();
            }
            else
            {
                CountDown = 0;
                //! Wait for Track time reset to complete
                while (TrackStatus.TrackTime > 0)
                {
                    Thread.Sleep(10);
                }
                CountDownTimer_Elapsed(countDownTimer, null);
            }
            trackStatus.PowerOverride = PreStartPower;
            updateTimer.Start();
        }

        /// <summary>
        /// Stop/cancel a race;
        /// </summary>
        public void StopRace()
        {
            updateTimer.Stop();
            trackStatus.StopTiming();
        }

        /// <summary>
        /// Reset timer and race info for all cars
        /// </summary>
        public void ClearRaceInfo()
        {
            trackStatus.ResetTiming();
        }

        /// <summary>
        /// Connect to serial comms and start the background service
        /// </summary>
        /// <param name="serialPort"></param>
        public void ConnectToTrack(string serialPort)
        {
            if (SerialPort.GetPortNames().Contains(serialPort))
            {
                bgs.StartService(serialPort);
                if (OnConnectionChanged != null)
                {
                    OnConnectionChanged.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Close serial comms with track and end comms thread.
        /// </summary>
        public void DisconnectFromTrack()
        {
            bgs.StopService();
        }

        /// <summary>
        /// BackGroundService stopped event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgs_OnBackGroundServiceStopped(object sender, EventArgs e)
        {
            if (OnConnectionChanged != null)
            {
                RaiseEventOnUIThread(OnConnectionChanged, e);
            }
        }

        /// <summary>
        /// CommsError event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgs_OnCommsError(object sender, CommsErrorEventArgs e)
        {
        }

        /// <summary>
        /// Raise an event on a different thread than the current one
        /// </summary>
        private void RaiseEventOnUIThread(Delegate theEvent, object args)
        {
            try
            {
                foreach (Delegate d in theEvent.GetInvocationList())
                {
                    ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                    if (syncer == null)
                    {
                        d.DynamicInvoke(new[] { this, args });
                    }
                    else
                    {
                        syncer.Invoke(d, new[] { this, args });  // cleanup omitted    
                    }
                }
            }
            catch (Exception)
            {
                //Exception code
            }
        }

    }
}

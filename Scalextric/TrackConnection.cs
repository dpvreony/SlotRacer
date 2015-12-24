using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scalextric
{
    public class TrackConnection
    {
        private static readonly int TIMEOUT = 200;
        private static readonly int LED_COUNT = 6;
        private static readonly int CAR_COUNT = 6;
        private SrComms comms;
        private string port;
        private Thread trackCommsThread;
        private Car[] cars = new Car[CAR_COUNT];
        private OutStatus cmd = new OutStatus();
        private LapTime lastLapTime = new LapTime();
        private bool threadRunning = false;
        private bool busy = false;

        public int RaceTime { get; private set; }
        public bool UpButtonDown { get; private set; }
        public bool DownButtonDown { get; private set; }
        public bool LeftButtonDown { get; private set; }
        public bool RightButtonDown { get; private set; }
        public bool EnterButtonDown { get; private set; }
        public bool StartButtonDown { get; private set; }
        public int[] CarsPowerOverride { get; private set; }
        public int PowerOverrideValue { get; private set; }

        public delegate void LapChangedEventHandler(object sender, LapChangedEventArgs e);
        public delegate void ConsoleButtonEventHandler(object sender, ConsoleButtonEventArgs e);

        public event LapChangedEventHandler OnLapChanged;
        public event ConsoleButtonEventHandler OnConsoleButtonDown;
        public event ConsoleButtonEventHandler OnConsoleButtonUp;
        public event EventHandler OnBrakePressed;
        public event EventHandler OnLaneChangePressed;

        public TrackConnection(string portName)
        {
            port = portName;
            CarsPowerOverride = new int[0];
            trackCommsThread = new Thread(UpdateTrack);
            cmd.Led = new bool[LED_COUNT];
            for (int i = 0; i < CAR_COUNT; i++)
            {
                cars[i] = new Car();
                cars[i].ID = i + 1;
            }
        }

        public void MaxPowerOverride(int[] carsToOverride, int maxPower)
        {
            PowerOverrideValue = maxPower;
            CarsPowerOverride = carsToOverride;
        }

        public void ClearPowerOverride()
        {
            CarsPowerOverride = new int[0];
            PowerOverrideValue = -1;
        }

        public void StopAllCars()
        {
            int[] allCars = new int[CAR_COUNT];
            for (int i = 1; i < CAR_COUNT+1; i++)
            {
                allCars[i-1] = i;
            }

            MaxPowerOverride(allCars, 0);
        }

        public void Connect()
        {
            comms = new SrComms(port);
            threadRunning = true;
            trackCommsThread.Start();
        }

        public void Disconnect()
        {
            threadRunning = false;
            if (trackCommsThread != null && trackCommsThread.IsAlive)
            {
                trackCommsThread.Join(1000);
            }
            comms.Dispose();
            comms = null;
        }

        public void SetCars(ref Car[] raceCars)
        {
            foreach (Car c in raceCars)
            {
                cars[c.ID - 1] = c;
            }
        }

        public void LedOn(int ledNr)
        {
            cmd.Led[ledNr] = true;
        }

        public void LedOff(int ledNr)
        {
            cmd.Led[ledNr] = true;
        
        }

        public void AllLedsOn()
        {
            for (int i = 0; i < cmd.Led.Length; i++)
            {
                cmd.Led[i] = true;
            }
        }

        public void AllLedsOff()
        {
            cmd.Led = new bool[LED_COUNT];
        }

        public int StartTiming()
        {
            while (busy) { }
            cmd.TimingStatus = RaceStatus.Started;
            DateTime to = DateTime.Now.AddMilliseconds(TIMEOUT);
            while (!cmd.CommandComplete)
            {
                if (to < DateTime.Now)
                {
                    return 0;
                }
            }
            return 1;
        }

        public int StopTiming()
        {
            while (busy) { }
            cmd.TimingStatus = RaceStatus.Stopped;
            DateTime to = DateTime.Now.AddMilliseconds(TIMEOUT);
            while (!cmd.CommandComplete)
            {
                if (to < DateTime.Now)
                {
                    return 0;
                }
            }
            return 1;
        }

        public int PauseTiming()
        {

            while (busy) { }
            cmd.TimingStatus = RaceStatus.Paused;
            DateTime to = DateTime.Now.AddMilliseconds(TIMEOUT);
            while (!cmd.CommandComplete)
            {
                if (to < DateTime.Now)
                {
                    return 0;
                }
            }
            return 1;
        }

        private void UpdateTrack()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            while (threadRunning)
            {
                sw.Start();
                cmd.Cars = cars;

                foreach (int id in CarsPowerOverride)
                {
                    if (cmd.Cars.Length >= id)
                    {
                        if (cmd.Cars[id - 1].Power > PowerOverrideValue)
                        {
                            cmd.Cars[id - 1].Power = PowerOverrideValue;
                        }
                    }
                }
                try
                {
                    busy = true;
                    InStatus inStat = comms.DoCommand(ref cmd);
                    busy = false;
                    if (inStat.Controllers == null)
                    {
                        continue;
                    }

                    int index = 0;
                    bool brakeDown = false;
                    bool changeDown = false;

                    foreach (Car car in cars)
                    {
                        car.UpdateCar(inStat.Controllers[index]);
                        if (inStat.Controllers[index].Connected && inStat.Controllers[index].BrakeButtonPressed) brakeDown = true;
                        if (car.LaneChange && car.ControllerConnected) changeDown = true;
                        index += 1;
                    }
                    if (inStat.LastLapTime.CarId > 0 && (lastLapTime != inStat.LastLapTime)) // race.RaceTime != inStat.RaceTimeOfLastCarToCross || lastCar != inStat.LatestCarToCross))
                    {
                        // Raise new event of carcrossedLine or something like that
                        Car c = null;
                        if (inStat.LastLapTime.CarId <= cars.Length)
                        {
                            c = cars[inStat.LastLapTime.CarId - 1];
                        }
                        RaiseEventOnUIThread(OnLapChanged, new LapChangedEventArgs(inStat.LastLapTime, c));
                    }
                    else if (inStat.LastLapTime.CarId == 0)
                    {
                        RaceTime = (int)inStat.LastLapTime.Time;
                    }
                    lastLapTime = inStat.LastLapTime;

                    if (changeDown)
                    {
                        //Raise LaneChangeDown Event
                        RaiseEventOnUIThread(OnLaneChangePressed, new EventArgs());
                    }
                    if (brakeDown)
                    {
                        //Raise LaneChangeDown Event
                        RaiseEventOnUIThread(OnBrakePressed, new EventArgs());
                    }

                    if (UpButtonDown != inStat.UpPressed)
                    {
                        if (inStat.UpPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Up));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Up));
                        }
                        UpButtonDown = inStat.UpPressed;
                    }
                    if (DownButtonDown != inStat.DownPressed)
                    {
                        if (inStat.DownPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Down));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Down));
                        }
                        DownButtonDown = inStat.DownPressed;
                    }
                    if (LeftButtonDown != inStat.LeftPressed)
                    {
                        if (inStat.LeftPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Left));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Left));
                        }
                        LeftButtonDown = inStat.LeftPressed;
                    }
                    if (RightButtonDown != inStat.RightPressed)
                    {
                        if (inStat.RightPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Right));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Right));
                        }
                        RightButtonDown = inStat.RightPressed;
                    }
                    if (EnterButtonDown != inStat.EnterPressed)
                    {
                        if (inStat.EnterPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Enter));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Enter));
                        }
                        EnterButtonDown = inStat.EnterPressed;
                    }
                    if (StartButtonDown != inStat.StartPressed)
                    {
                        if (inStat.StartPressed)
                        {
                            // Raise button down event
                            RaiseEventOnUIThread(OnConsoleButtonDown, new ConsoleButtonEventArgs(ConsoleButton.Start));
                        }
                        else
                        {
                            // Raise button up event
                            RaiseEventOnUIThread(OnConsoleButtonUp, new ConsoleButtonEventArgs(ConsoleButton.Start));
                        }
                        StartButtonDown = inStat.StartPressed;
                    }

                }
                catch (Exception e)
                {
                    busy = false;
                    // log error or something
                }
                long time = sw.ElapsedMilliseconds;
                sw.Stop();
            }
        }

        /// <summary>
        /// Raise an event on a different thread than the current one
        /// </summary>
        protected void RaiseEventOnUIThread(Delegate theEvent, object args)
        {
            if (theEvent != null)
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
                        //_thread.Join();
                    }
                }
                catch (Exception)
                {
                    //Exception code
                }
            }

        }

    }
}

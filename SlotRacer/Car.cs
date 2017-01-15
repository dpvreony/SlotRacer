using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotRacer
{
    /// <summary>
    /// This class represents a slot car
    /// </summary>
    public class Car
    {
        private static readonly int DEFAULT_MIN_LAPTIME = 1000; //By default the minimum laptime is 2000ms
        private static readonly int FULL_THROTTLE = 63;
        private static readonly float FUEL_THROTTLE_ADJUSTMENT = 0.3f; //Fuel level at which fuel stops effecting car performance
        private static readonly int NO_FUEL_SPEED = 16;
        private static readonly float REFUEL_TEMPO = 0.09f; // 100 / (80 * REFUEL_TEMPO) = [Number of seconds it takes to refuel]
        private static readonly double MAX_USAGE_PER_UPDATE = 0.03;

        private List<Int64> lapTimes = new List<Int64>();
        private bool lapZero = true;
        private Int64 _raceTime = 0;

        public int ID { get; set; }
        public Color Colour { get; set; }
        public Driver Driver { get; set; }
        public BrakeOption BrakeOption { get; set; }

        public bool UseFuel { get; set; }
        public double FuelLevel { get; set; }

        public int MinLapTime { get; set; }
        public int MaxPower { get; set; }
        public bool ControllerConnected { get; set; }
        public bool Brake { get; set; }
        public bool LaneChange { get; set; }
        public int Power { get; private set; }
        public Int64 RaceTime { get { return _raceTime; } }
        public int LapCount { get; private set; }
        public Int64[] LapTimes
        {
            get { return lapTimes.ToArray(); }
        }
        public bool RaceComplete { get; set; }
        public int GhostPower { get; set; }

        /// <summary>
        /// Time of last completed lap in ms
        /// </summary>
        public Int64 LastLap
        {
            get
            {
                if (LapTimes.Length > 0)
                {
                    return LapTimes[LapTimes.Length - 1];
                }
                else
                {
                    return 0;
                }
            }
        }

        public Int64 FastestLap
        {
            get
            {
                if (LapTimes.Length > 0)
                {
                    return LapTimes.Min();
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Car()
        {
            ID = 0;
            MaxPower = 63;
            BrakeOption = BrakeOption.OnButtonAndThrottle;
            _raceTime = 0;
            MinLapTime = DEFAULT_MIN_LAPTIME;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataRow"></param>
        public Car(DsSlots.DtRaceCarRow dataRow)
        {
            ID = dataRow.ControlerNr;
            MaxPower = dataRow.MaxPower;
            BrakeOption = (BrakeOption)dataRow.BrakeOption;
            _raceTime = 0;
            Colour = Color.FromName(dataRow.Colour);
            FuelLevel = 100;
            UseFuel = false;
            MinLapTime = DEFAULT_MIN_LAPTIME;
        }

        public  void GetData(ref DsSlots.DtRaceCarRow row)
        {
            row.BrakeOption = (short)this.BrakeOption;
            row.MaxPower = this.MaxPower;
            row.ControlerNr = ID;
            row.Description = "Not Implemented";
            if (Colour != null)
            {
                row.Colour = Colour.Name;
            }
        }

        /// <summary>
        /// Takes the data from the controler and applies it to the car. Taking into account any car settings.
        /// </summary>
        /// <param name="controller"></param>
        public void UpdateCar(Controller controller)
        {
            ControllerConnected = controller.Connected;
            if (ControllerConnected)
            {
                int throttle = controller.ThrottlePosition;
                if (UseFuel)
                {
                    if (FuelLevel < 100 && throttle == 0 && controller.BrakeButtonPressed && controller.LaneChangePressed)
                    {
                        FuelLevel = Math.Min(FuelLevel + REFUEL_TEMPO, 100);
                    }
                    FuelLevel -= MAX_USAGE_PER_UPDATE * ((double)throttle / FULL_THROTTLE);
                    if (FuelLevel <0) FuelLevel = 0;
                    if ((int)FuelLevel == 0 && throttle > NO_FUEL_SPEED)
                    {
                        throttle = NO_FUEL_SPEED;
                    }
                    else if (FuelLevel > 0)
                    {
                        throttle = (int)Math.Min(throttle - (FuelLevel / 100 * throttle) + (throttle * FUEL_THROTTLE_ADJUSTMENT), 100);
                    }
                }
                SetPower(throttle);
                Brake = ((controller.BrakeButtonPressed && (BrakeOption == BrakeOption.OnButton || BrakeOption == BrakeOption.OnButtonAndThrottle))
                    || (Power == 0 && (BrakeOption == BrakeOption.OnButtonAndThrottle || BrakeOption == BrakeOption.OnThrottleRelease)));
                LaneChange = controller.LaneChangePressed;
            }
            else
            {
                SetPower(GhostPower);
                Brake = (Power == 0);
                LaneChange = false;
            }
        }

        /// <summary>
        /// Set the power of the car;
        /// </summary>
        /// <param name="power"></param>
        public void SetPower(int power)
        {
            if (power <= MaxPower)
            {
                Power = power;
            }
            else
            {
                Power = MaxPower;
            }
        }

        /// <summary>
        /// Set the current race time
        /// </summary>
        /// <param name="time"></param>
        public void SetRaceTime(Int16 time)
        {
            _raceTime = time;
        }

        /// <summary>
        /// Add a given lap time to the list of laptimes.
        /// </summary>
        /// <param name="time"></param>
        public void AddLapTime(Int64 time)
        {
            if (!lapZero)
            {
                Int64 laptime = time - _raceTime;
                //! If lapTime is less than the minimum lap time, ignore the lap count
                if (laptime < MinLapTime)
                {
                    return;
                }
                lapTimes.Add(laptime);
                LapCount += 1;
            }
            else
            {
                lapZero = false;
            }
            _raceTime = time;
        }

        /// <summary>
        /// Clear all lap times and places car back in grid situation
        /// </summary>
        public void ResetLapCount()
        {
            lapZero = true;
            LapCount = 0;
            lapTimes.Clear();
            _raceTime = 0;
            RaceComplete = false;
        }

    }
}
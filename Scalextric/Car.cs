using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{
    public class Car
    {
        private static readonly int FULL_THROTTLE = 63;
        private static readonly float FUEL_THROTTLE_ADJUSTMENT = 0.3f; //Fuel level at which fuel stops effecting car performance
        private static readonly int NO_FUEL_SPEED = 16;
        private static readonly float REFUEL_TEMPO = 0.09f; // 100 / (80 * REFUEL_TEMPO) = [Number of seconds it takes to refuel]
        private static readonly double MAX_USAGE_PER_UPDATE = 0.03;
        private static readonly int GC_COMMAND_COUNT_LC_INTERVAL = 100; //Number of commands beteen ghost car lane change status changes

        private List<long> lapTimes = new List<long>();
        private bool lapZero = true;
        private bool ghostLaneChange = false;
        private int ghostLaneChangeCounter = 0;

        public int ID { get; set; }
        public Color Colour { get; set; }
        public Driver Driver { get; set; }
        public BrakeOption BrakeOption { get; set; }
        public static bool Racing { get; set; }

        public bool UseFuel { get; set; }
        public double FuelLevel { get; set; }

        public int MaxPower { get; set; }
        public bool ControllerConnected { get; set; }
        public bool Brake { get; set; }
        public bool LaneChange { get; set; }
        public int Power { get; set; }
        public long RaceTime { get; set; }
        public int LapCount { get; set; }
        public long[] LapTimes
        {
            get { return lapTimes.ToArray(); }
        }
        public bool RaceComplete { get; set; }

        public TimeSpan LastLap
        {
            get
            {
                if (LapTimes.Length > 0)
                {
                    return new DateTime(0).AddMilliseconds(LapTimes[LapTimes.Length - 1]).TimeOfDay;
                }
                else
                {
                    return new TimeSpan(0);
                }
            }
        }

        public TimeSpan FastestLap
        {
            get
            {
                if (LapTimes.Length > 0)
                {
                    return new DateTime(0).AddMilliseconds(LapTimes.Min()).TimeOfDay;
                }
                else
                {
                    return new TimeSpan(0);
                }
            }
        }

        public Car()
        {
            ID = 0;
            MaxPower = 63;
            BrakeOption = BrakeOption.OnButtonAndThrottle;
            RaceTime = 0;
        }

        public Car(DsSlots.DtRaceCarRow dataRow)
        {
            ID = dataRow.ControlerNr;
            MaxPower = dataRow.MaxPower;
            BrakeOption = (BrakeOption)dataRow.BrakeOption;
            RaceTime = 0;
            Colour = Color.FromName(dataRow.Colour);
            FuelLevel = 100;
            UseFuel = false;
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
                Power = (throttle > MaxPower) ? MaxPower : throttle;
                Brake = ((controller.BrakeButtonPressed && (BrakeOption == BrakeOption.OnButton || BrakeOption == BrakeOption.OnButtonAndThrottle))
                    || (Power == 0 && (BrakeOption == BrakeOption.OnButtonAndThrottle || BrakeOption == BrakeOption.OnThrottleRelease)));
                LaneChange = controller.LaneChangePressed;
            }
            else if (Racing) //If the controler is not connected, this becomes a ghost car.
            {
                ghostLaneChangeCounter += 1;
                if (ghostLaneChangeCounter > GC_COMMAND_COUNT_LC_INTERVAL)
                {
                    ghostLaneChangeCounter = 0;
                    ghostLaneChange = !ghostLaneChange;
                }
                Brake = false;
                Power = Properties.Settings.Default.GhostCarSpeed;
                switch (Properties.Settings.Default.GhostCarLaneChange)
                {
                    case 0:
                        LaneChange = false;
                        break;
                    case 1:
                        LaneChange = true;
                        break;
                    case 2:
                        LaneChange = ghostLaneChange;
                        break;
                }
            }
            else
            {
                Power = 0;
                ControllerConnected = false;
                Brake = true;
                LaneChange = false;
            }
        }

        public void AddLapTime(long time)
        {
            if (!lapZero)
            {
                long laptime = time - RaceTime;
                if (laptime < 0) laptime = laptime * (-1);
                
                lapTimes.Add(laptime);
                LapCount += 1;
            }
            else
            {
                lapZero = false;
            }
            RaceTime = time;
        }

        public void ResetLapCount()
        {
            lapZero = true;
            LapCount = 0;
            lapTimes.Clear();
            RaceTime = 0;
            RaceComplete = false;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotRacer
{
    public class TrackStatus
    {
        private static readonly int CAR_COUNT = 6;

        private bool[] leds = new bool[CAR_COUNT];

        //Returns the current race/timing status
        public RaceStatus RaceStatus { get; private set; }

        /// <summary>
        /// Get/Set power override for all cars.
        /// To disable PowerOverride, set value = -1
        /// </summary>
        public int PowerOverride { get; set; }

        /// <summary>
        /// Elapsed race time in ms.
        /// </summary>
        public Int64 TrackTime { get; private set; }

        /// <summary>
        /// Current drawn from the auxiliary port,(in mA)
        /// </summary>
        public int AuxiliaryPortCurrent { get; private set; }

        /// <summary>
        /// Indicates if the track is powered
        /// </summary>
        public bool TrackPowerOn { get; private set; }

        /// <summary>
        /// Array of cars in the system. (6 cars)
        /// </summary>
        public Car[] Cars { get; private set; }

        /// <summary>
        /// Event that occurs every time a car crosses the S/F line in a race
        /// Note, this event may not allways occur on UI thread
        /// </summary>
        public event EventHandler<LapChangedEventArgs> LapChanged;

        public TrackStatus()
        {
            Cars = new Car[CAR_COUNT];
            for (int i = 0; i < 6; i++)
            {
                Cars[i] = new Car();
                Cars[i].ID = i + 1;
            }
            RaceStatus = RaceStatus.Stopped;
        }

        /// <summary>
        /// Initialise the car from a datarow
        /// </summary>
        /// <param name="carId">ID of the car. (Integer between 1 and 6)</param>
        /// <param name="dataRow"></param>
        public void SetupCar(int carId , DsSlots.DtRaceCarRow dataRow)
        {
            if (carId > 0 && carId <= Cars.Length)
            {
                Cars[carId] = new Car(dataRow);
            }
        }

        /// <summary>
        /// Update the track Status with information received from Scalextric
        /// </summary>
        /// <param name="receivedStatus"></param>
        public void Update(InStatus receivedStatus)
        {
            AuxiliaryPortCurrent = receivedStatus.AuxPortCurrent;
            TrackPowerOn = receivedStatus.TrackPowered;
            int counter = 0;
            foreach (Controller c in receivedStatus.Controllers)
            {
                if (Cars.Length > counter)
                {
                    Cars[counter].UpdateCar(c);
                }
                counter += 1;
            }
            if (RaceStatus == RaceStatus.Started)
            {
                if (receivedStatus.LastLapTime.CarId > 0)
                {
                    Car c = Cars[receivedStatus.LastLapTime.CarId - 1];
                    c.AddLapTime(receivedStatus.LastLapTime.Time);
                    if (LapChanged != null)
                    {
                        LapChangedEventArgs ea = new LapChangedEventArgs(receivedStatus.LastLapTime, c);
                        LapChanged.Invoke(this, ea);
                    }
                }
                else
                {
                    TrackTime = receivedStatus.LastLapTime.Time;
                }
            }
            else if (RaceStatus == RaceStatus.Cleared)
            {
                TrackTime = 0;
            }
        }

        /// <summary>
        /// Returns an OutStatus instance that can be sent to Scalextric
        /// </summary>
        /// <returns></returns>
        public OutStatus GetOutStatus()
        {
            OutStatus stat = new OutStatus();
            stat.Cars =  (Car[])Cars.Clone();

            if (PowerOverride >= 0)
            {
                foreach(Car c in stat.Cars)
                {
                    c.SetPower(PowerOverride);
                }
            }

            for (int i = 0; i < Cars.Length; i++)
            {
                stat.SetLed(i, leds[i]);
            }
            stat.SetTimingStatus(RaceStatus);
            return stat;
        }

        /// <summary>
        /// Set an LED at a given index (0 - 5) on or off
        /// </summary>
        /// <param name="index"></param>
        /// <param name="on"></param>
        public void SetLed(int index, bool on)
        {
            if (index < CAR_COUNT)
            {
                leds[index] = on;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns the status of the LED at a given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetLed(int index)
        {
            if (index < CAR_COUNT)
            {
                return leds[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Start the race timer on the Scalextric console
        /// </summary>
        public void StartTiming()
        {
            RaceStatus = RaceStatus.Started;
        }

        /// <summary>
        /// Stop The current race
        /// </summary>
        public void StopTiming()
        {
            RaceStatus = RaceStatus.Stopped;
        }

        /// <summary>
        /// Reset race timer on the console
        /// when this function is called, racetime is not actually cleared until StartTiming is called 
        /// </summary>
        public void ResetTiming()
        {
            RaceStatus = RaceStatus.Cleared;
            for (int i=0; i< CAR_COUNT; i++)
            {
                Cars[i].ResetLapCount();
            }
        }
    }
}

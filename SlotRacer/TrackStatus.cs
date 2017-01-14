using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotRacer
{
    public class TrackStatus
    {
        private static readonly bool LED_ON = true;
        private static readonly bool LED_OFF = false;


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

        public long TimeCount { get; private set; }

        public TrackStatus()
        {
            Cars = new Car[6];
            for (int i = 0; i < 6; i++)
            {
                Cars[i].ID = i + 1;
            }
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
            if (receivedStatus.LastLapTime.CarId > 0)
            {
                Cars[receivedStatus.LastLapTime.CarId - 1].AddLapTime(receivedStatus.LastLapTime.Time);
            }
            else
            {
                TimeCount = receivedStatus.LastLapTime.Time;
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

            for (int i = 0; i < Cars.Length; i++ )
            {
                stat.SetLed(i, LED_ON);
            }
            stat.SetTimingStatus(RaceStatus.Started);
            return stat;
        }
    }
}

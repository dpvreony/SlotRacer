using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{
    public struct LapTime
    {
        public int CarId { get; set; }
        public Int64 Time { get; set; }

        public static bool operator ==(LapTime a, LapTime b)
        {
            return (a.CarId == b.CarId && a.Time == b.Time);
        }

        public static bool operator !=(LapTime a, LapTime b)
        {
            return (a.CarId != b.CarId || a.Time != b.Time);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    public struct Controller
    {
        public bool Connected { get; set; }
        public int ThrottlePosition { get; set; }
        public bool BrakeButtonPressed { get; set; }
        public bool LaneChangePressed { get; set; }
    }

    public class OutStatus
    {
        private static readonly bool LED_ON = true;
        private static readonly bool LED_OFF = false;
        private static readonly int RED_LED_INDEX = 6;
        private static readonly int GREEN_LED_INDEX = 7;
        public static readonly int LED_COUNT = 8;
        public static readonly int CAR_COUNT = 6;
        private RaceStatus timingStatus;
        private bool[] leds = new bool[LED_COUNT];
        private Car[] cars = new Car[6];

        public RaceStatus TimingStatus
        {
            get { return timingStatus; }
        }

        public bool[] Leds
        {
            get { return leds; }
        }

        public Car[] Cars { get; set; }
        public bool CommandComplete { get; set; }

        /// <summary>
        /// Turn on/off LED at given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="ledOn"></param>
        /// <returns></returns>
        public int SetLed(int index, bool ledOn)
        {
            if (index >= 0 && index < LED_COUNT-2)
            {
                leds[index] = ledOn;
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// Turn all LEDs off
        /// </summary>
        public void ClearLeds()
        {
            for(int i=0; i<LED_COUNT-2; i++)
            {
                leds[i] = false;
            }
        }

        /// <summary>
        /// Sets the TimingStatus property and sets the Green/Red LED's to match
        /// </summary>
        /// <param name="timing"></param>
        public void SetTimingStatus(RaceStatus timing)
        {
            switch (timing)
            {
                case RaceStatus.Started:
                    leds[RED_LED_INDEX] = LED_OFF;
                    leds[GREEN_LED_INDEX] = LED_ON;
                    break;
                case RaceStatus.Complete:
                    leds[RED_LED_INDEX] = LED_ON;
                    leds[GREEN_LED_INDEX] = LED_OFF;
                    break;
                default:
                    leds[RED_LED_INDEX] = LED_ON;
                    leds[GREEN_LED_INDEX] = LED_ON;
                    break;
            }

            timingStatus = timing;
        }
    }

    public struct InStatus
    {
        public bool TrackPowered { get; set; }
        public Controller[] Controllers { get; set; }
        public int AuxPortCurrent { get; set; }
        public LapTime LastLapTime { get; set; }
        //public int LatestCarToCross { get; set; }
        //public long RaceTimeOfLastCarToCross { get; set; }

        public bool UpPressed { get; set; }
        public bool DownPressed { get; set; }
        public bool LeftPressed { get; set; }
        public bool RightPressed { get; set; }
        public bool EnterPressed { get; set; }
        public bool StartPressed { get; set; }
    }

    public class Status
    {
    }


}

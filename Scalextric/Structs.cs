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

    public struct OutStatus
    {
        private RaceStatus timingStatus;
        private bool[] led; 

        public RaceStatus TimingStatus 
        {
            get { return timingStatus; }
            set
            {
                timingStatus = value;
                CommandComplete = false;
            }
        }
        public bool[] Led 
        {
            get { return led; }
            set
            {
                led = value;
                CommandComplete = false;
            }
        }
        public Car[] Cars { get; set; }
        public bool CommandComplete { get; set; }
    }

    public struct InStatus
    {
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

}

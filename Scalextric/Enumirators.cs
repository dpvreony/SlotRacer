using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{


    public enum BrakeOption
    {
        OnButton = 0,
        OnThrottleRelease = 1,
        OnButtonAndThrottle = 2,
        NoBraking = 3
    }

    public enum RaceType
    {
        Practice = 0,
        F1 = 1,
        Endurance = 2
    }

    public enum RaceStatus
    {
        Stopped = 0,
        Started = 1,
        Paused = 2,
        Complete = 3
    }

    public enum ConsoleButton
    {
        Up,
        Down,
        Left,
        Right,
        Enter,
        Start
    }

    public enum YelloFlagSetting
    {
        Disabled,
        BrakeButton,
        StartButton
    }

    public enum CommsErrorType
    {
        None,
        TimeOut,
        ChecksumError,
        ConnectionFailed
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{
    public class ConsoleButtonEventArgs : EventArgs
    {
        public ConsoleButton Button { get; private set; }

        public ConsoleButtonEventArgs(ConsoleButton button)
        {
            Button = button;
        }
    }

    public class LapChangedEventArgs : EventArgs
    {
        public Car Car { get; set; }
        public LapTime LapInfo { get; set; }

        public LapChangedEventArgs(LapTime lapInfo, Car c)
        {
            LapInfo = lapInfo;
            Car = c;
        }
    }

    public class CommsErrorEventArgs : EventArgs
    {
        public string ErrorText { get; set; }

        public CommsErrorEventArgs(string errorText)
        {
            ErrorText = ErrorText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlotRacer
{
    /// <summary>
    /// This class has a funcrion that runs in a seperate thread which sends and receives messages to the Scalextrick track.
    /// </summary>
    public class BackGroundService
    {
        private static readonly int MINPAUSETIME = 10;
        private static readonly int TIMEOUT_LIMIT = 3; //! Number of timeout errors before exiting connection thread.
        private TrackStatus status;
        private SrComms comms;
        private Thread thread;

        /// <summary>
        /// Indicates if the service has started
        /// </summary>
        public bool Started { get; private set; }

        public event EventHandler<CommsErrorEventArgs> OnCommsError;
        public event EventHandler OnBackGroundServiceStopped;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trackStatus"></param>
        public BackGroundService(ref TrackStatus trackStatus)
        {
            status = trackStatus;
            comms = new SrComms();
            Started = false;
        }

        /// <summary>
        /// Start the service thread and open the connection with the track
        /// </summary>
        /// <param name="serialPort"></param>
        public void StartService(string serialPort)
        {
            if (!Started)
            {
                Started = true;
                thread = new Thread(Run);
                thread.Start(serialPort);
            }
        }

        /// <summary>
        /// Stop the service thread and close the connection with the track
        /// </summary>
        public void StopService()
        {
            Started = false;
        }

        /// <summary>
        /// Main thread function
        /// </summary>
        /// <param name="obj"></param>
        private void Run(object obj)
        {
            string serialPort = (string)obj;
            DateTime nextSend = DateTime.Now;
            OutStatus outStat;
            InStatus inStat;
            int connection = 0;
            int toCount = 0;
            

            while (Started)
            {
                if (!comms.Connected)
                {
                    if (comms.Connect(serialPort) > 0)
                    {
                        RaiseEventOnUIThread(OnCommsError, new object[] { this, new CommsErrorEventArgs(CommsErrorType.ConnectionFailed, string.Empty) });
                        Started = false;
                        break;
                    }
                }
                outStat = status.GetOutStatus();

                //! Wait untill a minimum amount of time has passed before sending the next command otherwise Scalextric base crashes
                while (nextSend > DateTime.Now)  
                {
                    Thread.Sleep(1);
                }
                comms.SendCommand(outStat);
                connection = comms.GetReply(out inStat);
                nextSend = DateTime.Now.AddMilliseconds(MINPAUSETIME);
                //! If reply timed out
                if (connection == 1)
                {
                    toCount += 1;
                    if (toCount > TIMEOUT_LIMIT)
                    {
                        Started = false;
                        break; //break out of this for loop then break out of the thread
                    }
                    if (OnCommsError != null)
                    {
                        RaiseEventOnUIThread(OnCommsError, new object[] { this, new CommsErrorEventArgs(CommsErrorType.TimeOut, string.Empty) });
                    }
                }
                else if (connection == 0)
                {
                    toCount = 0;
                    status.Update(inStat);
                }
            }

            comms.Disconnect();
            Started = false;
            if (OnBackGroundServiceStopped != null)
            {
                RaiseEventOnUIThread(OnBackGroundServiceStopped,  new EventArgs());
            }
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

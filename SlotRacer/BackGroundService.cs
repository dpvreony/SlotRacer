using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlotRacer
{
    public class BackGroundService
    {
        private TrackStatus status;
        private SrComms comms;
        private Thread thread;

        /// <summary>
        /// Indicates if the service has started
        /// </summary>
        public bool Started { get; private set; }

        public event EventHandler<CommsErrorEventArgs> OnCommsError;
        public event EventHandler OnBackGroundServiceStopped;

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
            OutStatus outStat;
            InStatus inStat;
            int connection = 0;
            
            if (comms.Connect(serialPort) > 0)
            {
                RaiseEventOnUIThread(OnCommsError, new CommsErrorEventArgs(CommsErrorType.ConnectionFailed, string.Empty));
                Started = false;
            }

            while (Started)
            {
                outStat = status.GetOutStatus();

                for (int i = 0; i < 3; i++)
                {
                    comms.SendCommand(outStat);
                    connection = comms.GetReply(out inStat);

                    if (connection == 0)
                    {
                        break;
                    }
                    //! If reply timed out
                    else if (connection == 1)
                    {
                        Started = false;
                        if (OnCommsError != null)
                        {
                            RaiseEventOnUIThread(OnCommsError, new CommsErrorEventArgs(CommsErrorType.TimeOut, string.Empty));
                        }
                        break; //break out of this for loop then break out of the thread
                    }
                }
                if (connection==0)
                {

                }
            }

            comms.Disconnect();
            Started = false;
            if (OnBackGroundServiceStopped != null)
            {
                RaiseEventOnUIThread(OnBackGroundServiceStopped, new EventArgs());
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
                        d.DynamicInvoke(args);
                    }
                    else
                    {
                        syncer.Invoke(d, new[] { this, args });  // cleanup omitted    
                    }
                    //_thread.Join();
                }
            }
            catch //(Exception ex)
            {
                //Exception code
            }
        }
        
    }
}

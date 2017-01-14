using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{
    public class Race
    {
        private TrackStatus trackStatus;
        private BackGroundService bgs;

        public TrackStatus TrackStatus
        {
            get {return trackStatus;}
        }

        public bool Connected
        {
            get { return bgs.Started; }
        }

        #region Events

        /// <summary>
        /// Event that occurs when the serial connection wit the track changes
        /// </summary>
        public event EventHandler OnConnectionChanged;

        #endregion

        /// <summary>
        /// Race constructor
        /// </summary>
        public Race()
        {
            trackStatus = new TrackStatus();
            bgs = new BackGroundService(ref trackStatus);
            bgs.OnCommsError += bgs_OnCommsError;
            bgs.OnBackGroundServiceStopped += bgs_OnBackGroundServiceStopped;
        }

        /// <summary>
        /// Connect to serial comms and start the background service
        /// </summary>
        /// <param name="serialPort"></param>
        public void ConnectToTrack(string serialPort)
        {
            if (SerialPort.GetPortNames().Contains(serialPort))
            {
                bgs.StartService(serialPort);
                if (OnConnectionChanged != null)
                {
                    OnConnectionChanged.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Close serial comms with track and end comms thread.
        /// </summary>
        public void DisconnectFromTrack()
        {
            bgs.StopService();
        }

        /// <summary>
        /// BackGroundService stopped event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgs_OnBackGroundServiceStopped(object sender, EventArgs e)
        {
            if (OnConnectionChanged != null)
            {
                OnConnectionChanged.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// CommsError event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgs_OnCommsError(object sender, CommsErrorEventArgs e)
        {
        }


    }
}

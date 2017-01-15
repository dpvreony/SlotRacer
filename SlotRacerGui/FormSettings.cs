using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacerGui
{
    /// <summary>
    /// Form used to set Scalextric Settings
    /// </summary>
    public partial class FormSettings : Form
    {
        /// <summary>
        /// Get or set selected serial port;
        /// </summary>
        public string SerialPortName
        {
            get { return cmboPortName.Text; }
            set { cmboPortName.Text = value; }
        }

        /// <summary>
        /// Get/Set number of minutes in a countdown race
        /// </summary>
        public int RaceMinutes
        {
            get { return (int)nudRaceTime.Value; }
            set { nudRaceTime.Value = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
            cmboPortName.DataSource = SerialPort.GetPortNames();
        }

        /// <summary>
        /// Cancel button press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Ok button press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacerGui.Controls
{
    public partial class CarStatusDisplay : UserControl
    {
        private bool _displayHeadings = true;

        #region Public Properties
        public bool DisplayHeadings
        {
            get { return _displayHeadings; }
            set
            {
                if (value != _displayHeadings)
                {
                    _displayHeadings = value;
                    UpdateHeadings();
                }
            }
        }

        public string IdText
        {
            get { return lblCarId.Text; }
            set { lblCarId.Text = value; }
        }

        public bool LedOn
        {
            get { return chkLed1.Checked; }
            set { chkLed1.Checked = value; }
        }

        public string Power
        {
            get { return lblPow1.Text; }
            set { lblPow1.Text = value; }
        }

        public bool BrakeOn
        {
            get { return chkBrake1.Checked; }
            set { chkBrake1.Checked = value; }
        }
 
        public bool LaneChangeOn
        {
            get { return chkLc1.Checked; }
            set { chkLc1.Checked = value; }
        }

        public int MaxPower
        {
            get { return (int)nudMaxPower.Value; }
            set { nudMaxPower.Value = value; }
        }

        public int LapCount
        {
            get { return int.Parse(lblLapCount.Text); }
            set { lblLapCount.Text = value.ToString(); }
        }

        public float LapTime
        {
            get { return float.Parse(lblLapTime.Text); }
            set { lblLapTime.Text = value.ToString("000.000"); }
        }

        public float BestTime
        {
            get { return float.Parse(lblBestTime.Text); }
            set { lblBestTime.Text = value.ToString("000.000"); }
        }

        public int GhostPower
        {
            get { return (int)nudGhostPower.Value; }
            set { nudGhostPower.Value = value; }
        }

        #endregion

        #region Events
        public event EventHandler LedChanged;
        public event EventHandler MaxPowerChanged;
        public event EventHandler GhostPowerChanged;
        #endregion

        public CarStatusDisplay()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Runs when the DisplayHeadings property changes
        /// </summary>
        private void UpdateHeadings()
        {
            if (_displayHeadings)
            {
                panel1.Visible = true;
                Width += panel1.Width;
            }
            else
            {
                panel1.Visible = false;
                Width -= panel1.Width;
            }
        }

        private void chkLed1_CheckedChanged(object sender, EventArgs e)
        {
            if (LedChanged!= null)
            {
                LedChanged.Invoke(this, e);
            }
        }

        private void nudMaxPower_ValueChanged(object sender, EventArgs e)
        {
            if (MaxPowerChanged != null)
            {
                MaxPowerChanged.Invoke(this, e);
            }
        }

        private void nudGhostPower_ValueChanged(object sender, EventArgs e)
        {
            if (GhostPowerChanged != null)
            {
                GhostPowerChanged.Invoke(this, e);
            }
        }
    }
}

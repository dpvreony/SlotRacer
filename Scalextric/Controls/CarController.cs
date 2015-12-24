using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scalextric.Controls
{
    public partial class CarController : UserControl
    {

        private Color BrakeOffColour = Color.LightGray;
        private Color BrakeOnColour = Color.Green;
        private Color LcOffColour = Color.LightGray;
        private Color LcOnColour = Color.Blue;
        private bool brakeOn = false;
        private bool lcOn = false;

        public bool BrakeDown
        {
            get { return brakeOn; }
            set {
                brakeOn = value;
                if (brakeOn)
                {
                    pnlBrake.BackColor = BrakeOnColour;
                }
                else
                {
                    pnlBrake.BackColor = BrakeOffColour;
                }
            }
        }
        public bool LaneChangeDown
        {
            get { return lcOn; }
            set
            {
                lcOn = value;
                if (lcOn)
                {
                    pnlLc.BackColor = LcOnColour;
                }
                else
                {
                    pnlLc.BackColor = LcOffColour;
                }
            }
        }
        public int Throttle
        {
            get { return tbThrottle1.Value; }
            set { tbThrottle1.Value = value; }
        }
        public string Label
        {
            get { return lblCar.Text; }
            set { lblCar.Text = value; }
        }

        public event System.EventHandler ValueChanged;

        public CarController()
        {
            InitializeComponent();
        }

        private void btnBrake1_MouseDown(object sender, MouseEventArgs e)
        {
            BrakeDown = true;
        }

        private void btnBrake1_MouseUp(object sender, MouseEventArgs e)
        {
            BrakeDown = false;
        }

        private void btnLc1_MouseDown(object sender, MouseEventArgs e)
        {
            LaneChangeDown = true;
        }

        private void btnLc1_MouseUp(object sender, MouseEventArgs e)
        {
            LaneChangeDown = false;
        }

        private void tbThrottle1_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }

    }
}

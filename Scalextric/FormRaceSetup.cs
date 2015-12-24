using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scalextric
{
    public partial class FormRaceSetup : Form
    {
        public bool loading = true;

        public FormRaceSetup()
        {
            InitializeComponent();
        }

        private void FormYellowFlagSetup_Load(object sender, EventArgs e)
        {
            loading = true;
            tbSpeedAfterRace.Value = Properties.Settings.Default.SpeedAfterRace;
            cmboActivation.SelectedIndex = Properties.Settings.Default.YellowFlagActivation;
            nudDelay.Value = Properties.Settings.Default.YellowFlagDelay;
            trackBar1.Value = Properties.Settings.Default.YellowFlagSpeed;
            tbGhostCar.Value = Properties.Settings.Default.GhostCarSpeed;
            cmboGhostCarLaneChangeOption.SelectedIndex = Properties.Settings.Default.GhostCarLaneChange;
            loading = false;
        }

        private void tbSpeedAfterRace_ValueChanged(object sender, EventArgs e)
        {
            lblSpeedAfterRace.Text = Math.Round((float)tbSpeedAfterRace.Value * 100 / 63).ToString() + "%";
            if (!loading)
            {
                Properties.Settings.Default.SpeedAfterRace = tbSpeedAfterRace.Value;
            }

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblSpeed.Text = Math.Round((float)trackBar1.Value * 100 / 63).ToString() + "%";
            if (!loading)
            {
                Properties.Settings.Default.YellowFlagSpeed = trackBar1.Value;
            }
        }

        private void cmboActivation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                Properties.Settings.Default.YellowFlagActivation = cmboActivation.SelectedIndex;
            }
        }

        private void tbGhostCar_ValueChanged(object sender, EventArgs e)
        {
            lblGhostCarSpeed.Text = Math.Round((float)tbGhostCar.Value * 100 / 63).ToString() + "%";
            if (!loading)
            {
                Properties.Settings.Default.GhostCarSpeed = tbGhostCar.Value;
            }

        }

        private void cmboGhostCarLaneChangeOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                Properties.Settings.Default.GhostCarLaneChange = cmboGhostCarLaneChangeOption.SelectedIndex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }



    }
}

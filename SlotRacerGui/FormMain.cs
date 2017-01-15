using SlotRacer;
using SlotRacerGui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacerGui
{
    public partial class FormMain : Form
    {
        private static readonly string TXT_CONNECTED = "Connected";
        private static readonly string TXT_DISCONNECTED = "Disconnected";
        private static readonly string TXT_DISCONNECT = "Disconnect";
        private static readonly string TXT_CONNECT = "Connect";

        private Race race;
        private FormRaceWindow frmRace = new FormRaceWindow();
       public FormMain()
        {
            InitializeComponent();
            cmboRaceType.SelectedIndex = 0;
            race = new Race();
            race.OnConnectionChanged += Race_OnConnectionChanged;
            race.OnCountDownChanged += Race_OnCountDownChanged;
        }

        private void Race_OnCountDownChanged(object sender, EventArgs e)
        {
            bool show = race.TrackStatus.RaceStatus == RaceStatus.Cleared;
            frmRace.SetCountDown(race.CountDown, show);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            race.DisconnectFromTrack();
        }

        /// <summary>
        /// Settings Menu Click event handler.
        /// Opens settings Form and saves the settings on OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings();
            frmSettings.SerialPortName = Properties.Settings.Default.SerialPort;
            frmSettings.RaceMinutes = Properties.Settings.Default.RaceMinutes;
            if (frmSettings.ShowDialog(this)== DialogResult.OK)
            {
                Properties.Settings.Default.SerialPort = frmSettings.SerialPortName;
                Properties.Settings.Default.RaceMinutes = frmSettings.RaceMinutes;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Connect Menu click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (race.Connected)
            {
                race.DisconnectFromTrack();
            }
            else
            {
                race.ConnectToTrack(Properties.Settings.Default.SerialPort);
            }
        }

        /// <summary>
        /// Race.ConnectionChanged Event handler
        /// Sets the connection status in the status bar and the Connect menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Race_OnConnectionChanged(object sender, EventArgs e)
        {
            if (race.Connected)
            {
                btnStart.Enabled = true;
                lblConnectionStatus.Text = TXT_CONNECTED;
                btnConnect.Text = TXT_DISCONNECT;
                timer1.Start();
            }
            else
            {
                btnStart.Enabled = false;
                lblConnectionStatus.Text = TXT_DISCONNECTED;
                btnConnect.Text = TXT_CONNECT;
                timer1.Stop();
            }
        }

        /// <summary>
        /// CheckChance event handler for all LED CheckBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLed_CheckedChanged(object sender, EventArgs e)
        {
            //! Set the LED status in the TrackStatus to be updated on the track
            race.TrackStatus.SetLed(0, carDisplay1.LedOn);
            race.TrackStatus.SetLed(1, carDisplay2.LedOn);
            race.TrackStatus.SetLed(2, carDisplay3.LedOn);
            race.TrackStatus.SetLed(3, carDisplay4.LedOn);
            race.TrackStatus.SetLed(4, carDisplay5.LedOn);
            race.TrackStatus.SetLed(5, carDisplay6.LedOn);
        }

        /// <summary>
        /// While connected, update display every timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frmRace != null && frmRace.Visible)
            {
                frmRace.UpdateRace(race);
            }

            lblTime.Text = race.RaceTime.ToString(@"h\:mm\:ss");
            lblLap.Text = race.LeadingLap.ToString();



            carDisplay1.Power = Math.Round(race.TrackStatus.Cars[0].Power * 100f / 63f,0, MidpointRounding.AwayFromZero).ToString();
            carDisplay1.BrakeOn = race.TrackStatus.Cars[0].Brake;
            carDisplay1.LaneChangeOn = race.TrackStatus.Cars[0].LaneChange;
            carDisplay1.LapCount = race.TrackStatus.Cars[0].LapCount;
            carDisplay1.LapTime = (float)race.TrackStatus.Cars[0].LastLap / 1000;
            carDisplay1.BestTime = (float)race.TrackStatus.Cars[0].FastestLap / 1000;

            carDisplay2.Power = (race.TrackStatus.Cars[1].Power * 100 / 63).ToString();
            carDisplay2.BrakeOn = race.TrackStatus.Cars[1].Brake;
            carDisplay2.LaneChangeOn = race.TrackStatus.Cars[1].LaneChange;
            carDisplay2.LapCount = race.TrackStatus.Cars[1].LapCount;
            carDisplay2.LapTime = (float)race.TrackStatus.Cars[1].LastLap / 1000;
            carDisplay2.BestTime = (float)race.TrackStatus.Cars[1].FastestLap / 1000;

            carDisplay3.Power = (race.TrackStatus.Cars[2].Power * 100 / 63).ToString();
            carDisplay3.BrakeOn = race.TrackStatus.Cars[2].Brake;
            carDisplay3.LaneChangeOn = race.TrackStatus.Cars[2].LaneChange;
            carDisplay3.LapCount = race.TrackStatus.Cars[2].LapCount;
            carDisplay3.LapTime = (float)race.TrackStatus.Cars[2].LastLap / 1000;
            carDisplay3.BestTime = (float)race.TrackStatus.Cars[2].FastestLap / 1000;

            carDisplay4.Power = (race.TrackStatus.Cars[3].Power * 100 / 63).ToString();
            carDisplay4.BrakeOn = race.TrackStatus.Cars[3].Brake;
            carDisplay4.LaneChangeOn = race.TrackStatus.Cars[3].LaneChange;
            carDisplay4.LapCount = race.TrackStatus.Cars[3].LapCount;
            carDisplay4.LapTime = (float)race.TrackStatus.Cars[3].LastLap / 1000;
            carDisplay4.BestTime = (float)race.TrackStatus.Cars[3].FastestLap / 1000;

            carDisplay5.Power = (race.TrackStatus.Cars[4].Power * 100 / 63).ToString();
            carDisplay5.BrakeOn = race.TrackStatus.Cars[4].Brake;
            carDisplay5.LaneChangeOn = race.TrackStatus.Cars[4].LaneChange;
            carDisplay5.LapCount = race.TrackStatus.Cars[4].LapCount;
            carDisplay5.LapTime = (float)race.TrackStatus.Cars[4].LastLap / 1000;
            carDisplay5.BestTime = (float)race.TrackStatus.Cars[4].FastestLap / 1000;

            carDisplay6.Power = (race.TrackStatus.Cars[5].Power * 100 / 63).ToString();
            carDisplay6.BrakeOn = race.TrackStatus.Cars[5].Brake;
            carDisplay6.LaneChangeOn = race.TrackStatus.Cars[5].LaneChange;
            carDisplay6.LapCount = race.TrackStatus.Cars[5].LapCount;
            carDisplay6.LapTime = (float)race.TrackStatus.Cars[5].LastLap / 1000;
            carDisplay6.BestTime = (float)race.TrackStatus.Cars[5].FastestLap / 1000;
        }

        /// <summary>
        /// When the MaxPower property on a CarDisplay is changed, change the value in the track settings accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carDisplay_MaxPowerChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CarStatusDisplay))
            {
                int id;
                if (sender == carDisplay1) id = 0;
                else if (sender == carDisplay2) id = 1;
                else if (sender == carDisplay3) id = 2;
                else if (sender == carDisplay4) id = 3;
                else if (sender == carDisplay5) id = 4;
                else id = 5;
                float pow = ((CarStatusDisplay)sender).MaxPower * 63f / 100f;
                race.TrackStatus.Cars[id].MaxPower = (int)Math.Round(pow,0, MidpointRounding.AwayFromZero);
            }
        }

        private void carDisplay_GhostPowerChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CarStatusDisplay))
            {
                int id;
                if (sender == carDisplay1) id = 0;
                else if (sender == carDisplay2) id = 1;
                else if (sender == carDisplay3) id = 2;
                else if (sender == carDisplay4) id = 3;
                else if (sender == carDisplay5) id = 4;
                else id = 5;
                float pow = ((CarStatusDisplay)sender).GhostPower * 63f / 100f;
                race.TrackStatus.Cars[id].GhostPower = (int)Math.Round(pow,0, MidpointRounding.AwayFromZero);
            }
        }

        /// <summary>
        /// Start/stop the selected race type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (race.TrackStatus.RaceStatus == RaceStatus.Started)
            {
                race.StopRace();
                btnStart.Text = "Start";
            }
            else
            {
                race.ClearRaceInfo();
                race.EnduranceTime = Properties.Settings.Default.RaceMinutes * 60 * 1000;
                int hours = Properties.Settings.Default.RaceMinutes/60;
                int mins = Properties.Settings.Default.RaceMinutes - (hours * 60);
                if (cmboRaceType.SelectedIndex == 0)
                {
                    race.RaceType = RaceType.Practice;
                    lblTime.Text = new TimeSpan().ToString(@"h\:mm\:ss");
                }
                if (cmboRaceType.SelectedIndex == 1)
                {
                    race.RaceType = RaceType.Qualifying;
                    lblTime.Text = new TimeSpan(hours, mins, 0).ToString(@"h\:mm\:ss");
                }
                if (cmboRaceType.SelectedIndex == 2)
                {
                    race.RaceType = RaceType.F1;
                    lblTime.Text = new TimeSpan().ToString(@"h\:mm\:ss");
                }
                if (cmboRaceType.SelectedIndex == 3)
                {
                    race.RaceType = RaceType.Endurance;
                    lblTime.Text = new TimeSpan(hours,mins,0).ToString(@"h\:mm\:ss");
                }
                if (cmboRaceType.SelectedIndex != 0)
                {
                    OpenRaceForm();
                }
                btnStart.Text = "Stop";
                race.StartRace();
            }
        }

        private void OpenRaceForm()
        {
            frmRace = new FormRaceWindow();
            frmRace.Show(this);
        }
    }
}

using Scalextric.Controls;
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
    public partial class FormRace : Form
    {
        private List<CarDisplayControl> carDisplays = new List<CarDisplayControl>();
        private Car[] displayCars = new Car[0];
        private FormCountDown frmCountDown = new FormCountDown();

        public Race race { get; private set; }

        public FormRace(Race r)
        {
            InitializeComponent();
            race = r;
            frmCountDown.CountDownCompleted += frmCountDown_CountDownCompleted; 
            
            for (int i = 0; i < race.Cars.Length; i++)
            {
                CarDisplayControl cdc = new CarDisplayControl();
                carDisplays.Add(cdc);
                pnlRaceDisplay.Controls.Add(cdc);
                cdc.Dock = DockStyle.Top;
                cdc.Place = i + 1;
                cdc.Show();
            }
            for (int i = 0; i < race.Cars.Length; i++)
            {
                carDisplays[i].BringToFront();
            }
        }


        //public void SetDisplayCars(Car[] c)
        //{
        //    pnlRaceDisplay.Controls.Clear();
        //    displayCars = c;
        //    for (int i = 0; i < displayCars.Length; i++)
        //    {
        //        CarDisplayControl cdc = new CarDisplayControl();
        //        carDisplays.Add(cdc);
        //        pnlRaceDisplay.Controls.Add(cdc);
        //        cdc.Dock = DockStyle.Top;
        //        cdc.Place = i + 1;
        //        cdc.Show();
        //    }
        //    for (int i = 0; i < race.Cars.Length; i++)
        //    {
        //        carDisplays[i].BringToFront();
        //    }

        //}

        private void FormRace_Load(object sender, EventArgs e)
        {
            race.StopAllCars(true);
            frmCountDown.Show(this);
        }

        void frmCountDown_CountDownCompleted(object sender, EventArgs e)
        {
            race.StopAllCars(false);
            race.StartRace();
            timer1.Start();
        }

        private void FormRace_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRaceTime.Text = new DateTime(0).AddMilliseconds(race.RaceTime).ToString("H:mm:ss");
            lblLaps.Text = race.GetCompletedLaps().ToString();
            pbYellowFlag.Visible = race.YellowFlagEnabled;
            pbCheckeredFlag.Visible = (race.Status == RaceStatus.Complete);
            if (race.RaceType == RaceType.F1)
            {
                lblLaps.Text += "/" + race.LapsToRace;
            }
            int[] places = race.GetPlaceOrder();

            for (int i = 0; i < places.Length; i++)
            {
                carDisplays[i].Car = race.Cars[places[i]];
            }
        }
    }
}

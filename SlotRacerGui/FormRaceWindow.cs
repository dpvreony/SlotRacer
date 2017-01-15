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
    public partial class FormRaceWindow : Form
    {

        public FormRaceWindow()
        {
            InitializeComponent();
        }

        public void UpdateRace(Race race)
        {
            int[] carsInRace = race.CarsInRace;
            Car[] cars = race.TrackStatus.Cars;
            pnlCarDisplay.Controls.Clear();
            foreach (int c in carsInRace)
            {
                CarDisplayControl cdc = new CarDisplayControl();
                cdc.Car = cars[c-1];
                cdc.Dock = DockStyle.Top;
                pnlCarDisplay.Controls.Add(cdc);
            }
            
        }

        public void SetCountDown(int val, bool visable)
        {
            lblCountDown.Text = val.ToString();
            pnlCountDown.Visible = visable;
        }
    }
}

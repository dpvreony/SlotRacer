using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlotRacer;

namespace SlotRacerGui.Controls
{
    public partial class CarDisplayControl : UserControl
    {
        private Car c;

        public int Place
        {
            get { return int.Parse(lblPosition.Text); }
            set { lblPosition.Text = value.ToString(); }
        }

        public string Relative { get; set; }

        public Car Car
        {
            get { return c; }
            set
            {
                c = value;
                if (c != null)
                {
                    if (c.Driver != null)
                    {
                        lblDriverName.Text = c.Driver.Name;
                        //lblRelative.Text = c.
                        if (c.Driver.Icon != null)
                        {
                            pbImage.Image = c.Driver.Icon;
                        }
                        else
                        {
                            pbImage.Image = null;
                        }
                    }
                    else
                    {
                        lblDriverName.Text = "-";
                        pbImage.Image = null;
                    }
                    lblId.Text = c.ID.ToString();
                    lblLapCount.Text = c.LapCount.ToString();
                    lblLastLap.Text = c.LastLap.ToString(@"mm\:ss\.fff");
                    lblFastestLap.Text = c.FastestLap.ToString(@"mm\:ss\.fff");
                    BackColor = (c.Colour.Name == Color.Empty.Name) ? Color.White : c.Colour;
                    pbCheckeredFlag.Visible = c.RaceComplete;
                    fuelLevelControl1.Value = (int)Math.Round(c.FuelLevel,0);
                    fuelLevelControl1.ForeColor = (c.FuelLevel > 30) ? Color.LightGreen : (c.FuelLevel > 10) ? Color.OrangeRed : Color.Red;
                }
                else
                {
                    lblDriverName.Text = "-";
                    lblRelative.Text = "-";
                    lblLapCount.Text = "0";
                    lblLastLap.Text = "-";
                    lblFastestLap.Text = "-";
                }
            }

        }
        public CarDisplayControl()
        {
            InitializeComponent();
            
        }

    }
}

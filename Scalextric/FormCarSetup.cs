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
    public partial class FormCarSetup : Form
    {
        public Car Car { get; set; }

        public FormCarSetup( Car car)
        {
            InitializeComponent();
            this.Car = car;
            lblCarNr.Text = Car.ID.ToString();
            if (Car.Driver != null)
            {
                lblDriverName.Text = Car.Driver.Name;
            }
            if (car.Colour != null)
            {
                cmboColour.Text = car.Colour.Name;
            }
            trackBar1.Value = Car.MaxPower;
            cmboBrakeBehaviour.SelectedIndex = (int)Car.BrakeOption;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblSpeed.Text = Math.Round((float)trackBar1.Value * 100 / 63).ToString() + "%";
            Car.MaxPower = trackBar1.Value;
        }

        private void cmboBrakeBehaviour_SelectedIndexChanged(object sender, EventArgs e)
        {
            Car.BrakeOption = (BrakeOption)cmboBrakeBehaviour.SelectedIndex;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlColour_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnlColour.BackColor;
            if (colorDialog1.ShowDialog(this)== System.Windows.Forms.DialogResult.OK)
            {
                pnlColour.BackColor = colorDialog1.Color;
                Car.Colour = colorDialog1.Color;
            }
        }

        private void cmboColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlColour.BackColor = Color.FromName(cmboColour.Text);
            Car.Colour = pnlColour.BackColor;
        }
    }
}

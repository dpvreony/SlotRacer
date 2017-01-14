using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacer
{
    public partial class FormDriver : Form
    {
        private string image = string.Empty;

        public string Drivername
        {
            get { return txtDriverName.Text; }
            set { txtDriverName.Text = value; }
        }

        public string Icon
        {
            get { return image; }
            set
            {
                try
                {
                    Bitmap icon = new Bitmap(value);
                    pictureBox1.Image = icon;
                    image = value;
                }
                catch { }
            }
        }

        public FormDriver()
        {
            InitializeComponent();
        }

        public FormDriver(string name, string image)
        {
            InitializeComponent();
            this.Drivername = name;
            this.Icon = image;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this)== System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Bitmap icon = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = icon;
                    image = openFileDialog1.FileName;
                }
                catch 
                { }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}

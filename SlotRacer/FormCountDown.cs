using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacer
{
    public partial class FormCountDown : Form
    {
        private int startCount = 5;

        public event EventHandler CountDownCompleted;

        public FormCountDown()
        {
            InitializeComponent();
            lblCd.Text = startCount.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startCount == 0)
            {
                this.Close();
            }
            startCount -= 1;
            lblCd.Text = startCount.ToString();
            if (startCount == 0)
            {
                this.BackColor = Color.Green;
                if (CountDownCompleted != null)
                {
                    CountDownCompleted(this, new EventArgs());
                }
            }
        }

        private void FormCountDown_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

    }
}

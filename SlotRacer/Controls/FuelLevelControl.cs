using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotRacer.Controls
{
    public partial class FuelLevelControl : UserControl
    {
        private static readonly int MAX_VALUE = 100;
        private int val = 100;

        public int Value 
        {
            get { return val; }
            set
            {
                if (value != val)
                {
                    val = value;
                    Refresh();
                }
            }
        }

        public FuelLevelControl()
        {
            InitializeComponent();
            Value = 50;
            ForeColor = Color.Red;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;

            SolidBrush bgBrush = new SolidBrush(BackColor);
            SolidBrush brush = new SolidBrush(ForeColor);
            Pen pen = new Pen(Color.Black, 2);
            int tempWidth =  this.Width * Value / MAX_VALUE;
            Rectangle r = new Rectangle(0, 0, tempWidth, Height);
            g.FillRectangle(bgBrush, 0, 0, Width, Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, 0, 0, Width-2, Height-2);
        }

        private void FuelLevelControl_ForeColorChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}

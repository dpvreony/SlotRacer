using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalextric
{
    public class Driver
    {
        public string Name { get; set; }
        public Image Icon { get; set; }

        public Driver()
        {

        }

        public Driver(DsSlots.DtDriverRow row)
        {
            Name = row.Name;
            try
            {
                Icon = Image.FromFile(row.Image);
            }
            catch { }
        }

    }
}

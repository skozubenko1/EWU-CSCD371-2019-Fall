using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Television : Item
    {
        public String Manufacturer { get; set; }
        public String Size { get; set; }

        public override string PrintInfo()
        {
            return $"{Manufacturer} - {Size}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Animals.Birds
{
    class Wing
    {
        public double WingLength { get; set; }

        public Wing()
        {
            Random r = new Random();
            WingLength = r.Next(4,15);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Misc;

namespace OOPBriefing.Rodents
{
    class Fur
    {
        public Color FurColor { get; set; }
        public Density FurDensity { get; set; }

        public Fur()
        {
            FurColor = (Color)(new Random().Next(0, 3));
            FurDensity = (Density)(new Random().Next(0, 2));
        }

        public Fur(Color color,Density density)
        {
            FurColor = color;
            FurDensity = density;
        }

    }
}

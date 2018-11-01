using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Misc;

namespace OOPBriefing.Rodents
{
    class Thorn
    {
        public Color ThornColor { get; set; }
        public int ThornLength { get; set; }
        public Density ThornDensity { get; set; }

        public Thorn()
        {
            ThornColor = (Color)(new Random().Next(0,3));
            ThornLength = new Random().Next(3, 5);
            ThornDensity = (Density)(new Random().Next(1, 3));
        }

        public Thorn(Color color,int length,Density density)
        {
            ThornColor = color;
            ThornLength = length;
            ThornDensity = density;
        }

    }
}

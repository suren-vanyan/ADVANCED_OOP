using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Misc;

namespace OOPBriefing.Animals.Birds
{
    class Feather
    {

        public Color Color1 { get; set; }
        public Color Color2 { get; set; }

        public Feather()
        {
            Random r = new Random();
            Color1 = (Color)r.Next(0, 3);
            Color2 = (Color)r.Next(0, 3);
        }
        
    }

    


}

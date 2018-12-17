using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Rudents;

namespace OOPBriefing.Animals.Birds
{
    class Owl : PredatorBird
    {
        public Owl()
        {

        }
        public override Animal Hunt()
        {
            return new Rat();
        }
    }
}

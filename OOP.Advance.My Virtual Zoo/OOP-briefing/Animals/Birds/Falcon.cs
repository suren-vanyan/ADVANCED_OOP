using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Rudents;

namespace OOPBriefing.Animals.Birds
{
    class Falcon : PredatorBird
    {
        public Falcon()
        {

        }
        public override Animal Hunt()
        {
            return new Squirrel();
        }
    }
}

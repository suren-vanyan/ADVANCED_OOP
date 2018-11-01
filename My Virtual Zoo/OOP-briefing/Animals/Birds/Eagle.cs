using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Worlds;

namespace OOPBriefing.Animals.Birds
{
    class Eagle : PredatorBird
    {
        public Eagle()
        {

        }
        public Feather Feather2 { get; set; }

        public int WatchArea2MinRadius { get; set; }
        public int WatchArea2MaxRadius { get; set; }

        public override Animal Hunt()
        {
            return new Penguin();
        }

        public void SpecialWatch(World world)
        {

        }
    }
}

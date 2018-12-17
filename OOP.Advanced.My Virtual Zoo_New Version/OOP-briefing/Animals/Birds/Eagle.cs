using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Worlds;

namespace OOPBriefing.Animals.Birds
{
    class Eagle : PredatorBird
    {
        public Feather Feather2 { get; set; }

        public int WatchArea2MinRadius { get; set; } //random
        public int WatchArea2MaxRadius { get; set; } //random

        public Eagle(string name):base(name,true,true)
        {
            Feather2 = new Feather();
            WatchArea2MinRadius = new Random().Next(5,10);
            WatchArea2MaxRadius = new Random().Next(15, 20);
            OnCreateNewAnimale(this);
        }

        public Eagle():base()
        {

        }

        public override Animal Hunt()
        {
            return new Penguin();
        }

        public void SpecialWatch(World world)
        {

        }

        
    }
}

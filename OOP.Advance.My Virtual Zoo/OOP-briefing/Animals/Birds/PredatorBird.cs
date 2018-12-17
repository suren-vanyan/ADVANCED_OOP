using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;

namespace OOPBriefing.Animals.Birds
{
    abstract class PredatorBird : Bird
    {
        
        public PredatorBird()
        {
            Random rnd = new Random();
            WatchAreaRadius = rnd.Next(30, 35);
        }
        public override void Eat(Food food)
        {
            if (food is Meat meat)
            {
                Energy = Energy + meat.Energy;
            }
        }

        public abstract Animal Hunt();
        
    }
}

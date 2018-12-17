using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;

namespace OOPBriefing.Animals.Birds
{
    abstract class HerbivorousBird : Bird
    {
        public HerbivorousBird()
        {
            Random rnd = new Random();
            WatchAreaRadius = rnd.Next(15,20);
        }
        public override void Eat(Food food)
        {
            if (food is Plant plant)
            {
                Energy = Energy + plant.Energy;
            }
        }
    }
}

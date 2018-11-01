using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;

namespace OOPBriefing.Animals.Birds
{
    abstract class HerbivorousBird : Bird
    {

        public HerbivorousBird(string name,bool canWalk,bool canFly):base(name,canWalk,canFly)
        {

        }

        public HerbivorousBird():base()
        {

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

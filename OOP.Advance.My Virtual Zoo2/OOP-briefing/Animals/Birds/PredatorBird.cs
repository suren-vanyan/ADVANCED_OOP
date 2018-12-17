using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;

namespace OOPBriefing.Animals.Birds
{
    abstract class PredatorBird : Bird
    {

        public PredatorBird(string name,bool canWalk,bool canFly):base(name,canWalk,canFly)
        {

        }

        public PredatorBird():base()
        {

        }

        public override void Eat(Food food)
        {
            if (food is Meat meat)
            {
                Energy = Energy + meat.Energy;
            }
        }

        public abstract Animal Hunt();//?
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Animals;
using OOPBriefing.Animals.Birds;
using OOPBriefing.Worlds;
using OOPBriefing.Foods;

namespace OOPBriefing.Rodents
{
    abstract class Rodent : Animal
    {

        public double Speed { get; set; } //random      
        public Fur Fur { get; set; }

        public Rodent(string name):base(name)
        {
            Fur = new Fur();
            Speed = new Random().Next(2,6);
        }
        
        public Rodent():base()
        {

        }
        
        public void Walk(int time,Direction direction,BackOrForward backOrForward) {
            if (time * EnergyPerTime >= Energy)
            {
                Console.WriteLine("Sorry but this rudent has no enough energy");
            }
            else
            {
                if (direction.Equals(Direction.XDirection))
                {
                    Location.XCoord += (int)(time * Speed) * ((int)backOrForward);
                    Energy -= time * EnergyPerTime;
                }
                else if (direction.Equals(Direction.YDirection))
                {
                    Location.YCoord += (int)(time * Speed) * ((int)backOrForward);
                    Energy -= time * EnergyPerTime;
                }
                else
                {
                    Console.WriteLine("Sorry buth that is not posible");
                }
            }
            if (Energy <= 10)
            {
                OnAnimalDied(this);
            }
        }
       
        public override void Eat(Food food)
        {
            if (food is Plant)
            {
                Energy += food.Energy;
            }
        }

        

    }
}

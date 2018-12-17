using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Animals;
using OOPBriefing.Animals.Birds;
using OOPBriefing.Worlds;
using OOPBriefing.Foods;

namespace OOPBriefing.Rudents
{
    abstract class Rudent : Animal
    {
        public Rudent()
        {
            Random rnd = new Random();
            WatchAreaRadius = rnd.Next(20, 25);
        }

        public double Speed { get; set; }
        //public int WatchAreaRadius { get; set; }
        public Fur Fur { get; set; }

        public void Walk(int time,Direction direction,BackOrForward backOrForward) {
            if (time * EnergyPerTime >= Energy)
            {
                Console.WriteLine($"Sorry but {this.Name} has no enough energy");
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

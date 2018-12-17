using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rudents;

namespace OOPBriefing.Animals.Birds
{
    abstract class Bird : Animal
    {
        //public string Name { get; set; }    
        //public int Energy { get; set; }
        //public int Hitpoints { get; set; }
        //public int Power { get; set; }
        //public int EnergyPerTime { get; set; }
        public bool CanWalk { get; set; }
        public double WalkingSpeed { get; set; }
        public bool CanFly { get; set; }
        public double FlyingSpeed { get; set; }
        public double MaxFlyingHeight { get; set; } 
        public Feather Feather { get; set; }
        public Wing Wing { get; set; }
    
        public Meat Meat { get; set; }
       
        public static int Population { get; set; }

        protected Bird()
        {
            Population++;
        }

        

        public void Fly(int time, Direction direction,BackOrForward backOrForward)
        {
            if (CanFly)
            {

                if (time * EnergyPerTime >= Energy)
                {
                    Console.WriteLine($"Sorry but {this.Name} has no enough energy!");
                }
                else
                {
                    if (direction.Equals(Direction.XDirection))
                    {
                        Location.XCoord += (int)(time*FlyingSpeed*(int)backOrForward);
                        Energy -= time * EnergyPerTime;
                    }
                    else if (direction.Equals(Direction.YDirection))
                    {
                        Location.YCoord += (int)(time * FlyingSpeed * (int)backOrForward);
                        Energy -= time * EnergyPerTime;
                    }
                    else if(direction.Equals(Direction.ZDirection))
                    {
                        Location.ZCoord += (int)(time * FlyingSpeed * (int)backOrForward);
                        Energy -= time * EnergyPerTime;
                    }
                }
            }
        }

        public void Walk(int time, Direction direction,BackOrForward backOrForward)
        {
            if (CanWalk)
            {
                if (time * EnergyPerTime >= Energy)
                {
                    Console.WriteLine($"Sorry but {this.Name} has no enough energy!");
                }
                else
                {


                    switch(direction)
                    {
                        case Direction.XDirection:
                            Location.XCoord += (int)(time * WalkingSpeed * (int)backOrForward);
                            Energy -= time * EnergyPerTime;
                            break;
                        case Direction.YDirection:
                            Location.YCoord += (int)(time * WalkingSpeed * (int)backOrForward);
                            Energy -= time * EnergyPerTime;
                            break;
                        case Direction.ZDirection:
                            Console.WriteLine("Sorry but that is not posible");
                            break;
                        default:
                            break;

                    }
                }
            }
        }

        public static explicit operator Bird(string v)
        {
            throw new NotImplementedException();
        }
       
        public void Rest(int time)
        {

        }

        
    }
}

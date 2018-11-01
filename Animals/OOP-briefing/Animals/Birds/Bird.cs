using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rodents;

namespace OOPBriefing.Animals.Birds
{
    abstract class Bird : Animal
    {
        
        public bool CanWalk { get; set; }
        public double WalkingSpeed { get; set; } // 5-10
        public bool CanFly { get; set; }
        public double FlyingSpeed { get; set; } // 10-25
        public double MaxFlyingHeight { get; set; } // 60 World.MaxZ
        public Feather Feather { get; set; }
        public Wing Wing { get; set; }
        public Meat Meat { get; set; }
        public static int Population { get; set; }

        public Bird(string name,bool canWalk,bool canFly):base(name)
        {
            
            Population = Population + 1;
            Feather = new Feather();
            Wing = new Wing();
            Meat = new Meat();
            CanFly = canFly;
            CanWalk = canWalk;
            double GetRandomDouble(Random random, double min, double max)
            {
                return min + (random.NextDouble() * (max - min));
            }
            WalkingSpeed = GetRandomDouble(new Random(),5,10);
            FlyingSpeed = GetRandomDouble(new Random(),10,25);
            MaxFlyingHeight = GetRandomDouble(new Random(),60,World.SizeZ);

        }

        public Bird():base()
        {

        }

        public void Fly(int time, Direction direction,BackOrForward backOrForward)
        {
            if (CanFly)
            {

                if (time * EnergyPerTime >= Energy)
                {
                    Console.WriteLine("Sorry but this bird has no enough energy!");
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
                if (Energy <= 10)
                {
                    OnAnimalDied(this);
                }
            }
        }

        public void Walk(int time, Direction direction,BackOrForward backOrForward)
        {
            if (CanWalk)
            {
                if (time * EnergyPerTime >= Energy)
                {
                    Console.WriteLine("Sorry but this bird has no enough energy!");
                }
                else
                {
                    if (direction.Equals(Direction.XDirection))
                    {
                        Location.XCoord += (int)(time * WalkingSpeed * (int)backOrForward);
                        Energy -= time * EnergyPerTime;
                    }
                    else if (direction.Equals(Direction.YDirection))
                    {
                        Location.YCoord += (int)(time * WalkingSpeed * (int)backOrForward);
                        Energy -= time * EnergyPerTime;
                    }
                    else
                    {
                        Console.WriteLine("Sorry but that is not posible");
                    }
                }
                if (Energy <= 10)
                {
                    OnAnimalDied(this);
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

using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rodents;
using OOPBriefing.Animals.Birds;

namespace OOPBriefing.Animals
{
    abstract class Animal
    {

        public delegate void AnimalStatusHandler(object o);
        public static event AnimalStatusHandler NewAnimal;
        public static event AnimalStatusHandler DieAnimal;

        public string Name { get; set; }
        public int Energy { get; set; } // random
        public int Hitpoints { get; set; } // random
        public int Power { get; set; } //random
        public int EnergyPerTime { get; set; } //random
        public int WatchAreaRadius { get; set; } //random
        private Location _location;  //random
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public Animal()
        {
            
        }

        public Animal(string name)
        {
            Name = name;
            Random rand = new Random();            
            _location = new Location(rand.Next(0, World.SizeX), rand.Next(0, World.SizeY),rand.Next(0, World.SizeZ));
            Energy = rand.Next(10, 121);
            Hitpoints = rand.Next(5, 11);
            Power = rand.Next(1, 4);
            EnergyPerTime = rand.Next(1, 16);
            WatchAreaRadius = rand.Next((int)World.SizeX/6,(int)(World.SizeX + 1)/4);
            
        }

        public static void OnCreateNewAnimale(object o)
        {
            NewAnimal?.Invoke(o);
        }

        public static void OnAnimalDied(object o)
        {
            DieAnimal?.Invoke(o);
        }

        public abstract void Eat(Food food);

        public virtual List<Animal> Watch() {
            List<Animal> canWatch = new List<Animal>();
            
            double CalculateDistance(Animal animal1,Animal animal2)
            {
                return Math.Sqrt(Math.Pow(animal2.Location.XCoord-animal1.Location.XCoord,2) +
                    Math.Pow(animal2.Location.YCoord - animal1.Location.YCoord, 2) +
                    Math.Pow(animal2.Location.ZCoord - animal1.Location.ZCoord, 2));
            }

            foreach (Animal a in World.Animals)
            {
                if (!this.Equals(a)) {
                    if (CalculateDistance(this,a) <= WatchAreaRadius) {
                        canWatch.Add(a);
                    }
                }
            }

            
            return canWatch;
        }

        

        public override string ToString()
        {
            return "[ Name - "+Name+",Energy - "+Energy+", "+Location.ToString()+ ", Hitpoints -"+Hitpoints
                +", Power-"+Power
                + " ]";
        }
    }
}

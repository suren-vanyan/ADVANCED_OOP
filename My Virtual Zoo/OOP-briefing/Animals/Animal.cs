using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rudents;
using OOPBriefing.Animals.Birds;

namespace OOPBriefing.Animals
{
    abstract class Animal
    {
       
        public string Name { get; set; }
        public int Energy { get; set; }  // 10-120
        public int Hitpoints { get; set; } // 5-10
        public int Power { get; set; } //1-3
        public int EnergyPerTime { get; set; } //1-15
        public virtual int WatchAreaRadius { get; set; }//World.Size/6 - World.Size/4
        Direction direction { get; set; }
        private Location _location;
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

        protected Animal()
        {
            Random rand = new Random();            
            _location = new Location(rand.Next(0, World.SizeX), rand.Next(0, World.SizeY),rand.Next(0, World.SizeZ));
            Energy = rand.Next(10 , 120);
            Hitpoints = rand.Next(5 , 10);
            Power= rand.Next(1,3);
            EnergyPerTime = rand.Next(1, 15);
            
        }

        public abstract void Eat(Food food);

        public virtual List<Animal> Watch()
        {
            List<Animal> canWatch = new List<Animal>();
            
            var areaXFront = Location.XCoord + WatchAreaRadius;
            var areaXBack = Location.XCoord - WatchAreaRadius;
            var areaYFront = Location.YCoord + WatchAreaRadius;
            var areaYBack = Location.YCoord - WatchAreaRadius;
            var areaZFront = Location.ZCoord + WatchAreaRadius;
            var areaZBack = Location.ZCoord - WatchAreaRadius;




            foreach (Animal r in World.Animals)
            {
                if (r.Location.XCoord < areaXFront && r.Location.XCoord > areaXBack)
                {
                    if (r.Location.YCoord < areaYFront && r.Location.YCoord > areaYBack)
                    {
                        if (r.Location.ZCoord < areaZFront && r.Location.ZCoord > areaZBack)
                        {
                            if (!this.Equals(r))
                            {
                                canWatch.Add(r);
                            }
                        }
                    }
                }
            }

            

            return canWatch;
        }

        public override string ToString()
        {
            return $"{Name}   Energy--{Energy}, {Location.ToString()} \n";
        }
    }
}

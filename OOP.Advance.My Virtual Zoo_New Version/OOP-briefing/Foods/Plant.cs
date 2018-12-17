using System;
using OOPBriefing.Worlds;

namespace OOPBriefing.Foods
{
    class Plant : Food  
    {
        public string Name { get; set; }
        public Location Location { get; set; } 
        public Plant()
        {
            Location=new Location();
            var rnd = new Random();
            Location.XCoord = rnd.Next(0,World.SizeX-1);
            Location.YCoord = rnd.Next(0, World.SizeY - 1);
            Location.ZCoord = rnd.Next(0, World.SizeZ - 1);
        }
    }
}

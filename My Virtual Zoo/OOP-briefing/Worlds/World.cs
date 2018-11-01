using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Animals.Birds;
using OOPBriefing.Rudents;
using OOPBriefing.Animals;

namespace OOPBriefing.Worlds
{
    class World
    {
        public static int SizeX;
        public static int SizeY;
        public static int SizeZ;
        public static List<Animal> Animals { get; set; } = new List<Animal>();
        public Plant[] Plants { get; set; }

        public World(int x, int y, int z)
        {
            SizeX = x;
            SizeY = y;
            SizeZ = z;
        }
    }   
}

using OOPBriefing.Animals.Birds;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rodents;
using OOPBriefing.Animals;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OOPBriefing
{
    class Program
    {
        public static World World;
        static void Main(string[] args)
        {
            
            World = new World(100, 100, 100);

            Eagle eagle1 = new Eagle("Eagle_1");
            Eagle eagle2 = new Eagle("Eagle_2");

            new Colibri("Colibri_1");
            new Falcon("Falcon_1");
            new Owl("Owl_1");
            new Penguin("Penguin_1");
            new Colibri("Colibri_2");
            new Falcon("Falcon_2");
            new Owl("Owl_2");
            new Penguin("Penguin_2");

            Beaver beaver1 = new Beaver("Beaver_1");
            new Hamster("Hamster_1");
            new Porcupine("Porcupine_1");
            new Rat("Rat_1");
            new Squirrel("Squirel_1");
            new Beaver("Beaver_2");
            new Hamster("Hamster_2");
            new Porcupine("Porcupine_2");
            new Rat("Rat_2");
            Squirrel squirel2 = new Squirrel("Squirel_2");

            Thread.Sleep(2000);
            Console.Clear();
            
            
            for (int i = 0;i<200;i++)
            {
                World.MoveAnimals();
                Console.WriteLine(World);
                Thread.Sleep(1000);
                Console.Clear();
            }
            
        }
    }
}

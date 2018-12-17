using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;
using OOPBriefing.Animals.Birds;
using OOPBriefing.Rodents;
using OOPBriefing.Animals;

namespace OOPBriefing.Worlds
{
    class World
    {

        public delegate int BackOrForwardHandler(int n);

        public static int SizeX;
        public static int SizeY;
        public static int SizeZ;
        public static List<Animal> Animals;
        public Plant[] Plants { get; set; }

        static World() {
            Animals = new List<Animal>();
            Animal.NewAnimal += NewAnimalCreated;
            Animal.DieAnimal += AnimalDied;
        }

        private static void NewAnimalCreated(object o)
        {
            Animal a = o as Animal;
            if (a != null)
            {
                Console.WriteLine("[ "+a.Name+" ]"+" animal have been added");               
                Animals.Add(a);
            }
            else
            {
                Console.WriteLine("Error");
            }           
        }

        private static void AnimalDied(object o)
        {
            Animal a = o as Animal;
            if (a != null)
            {
                Console.WriteLine(a.ToString()+" DIEDDDDDDDDDDDDDDD!!");
                //Animals.Remove(a);
            }
            
        }

        

        public override string ToString()
        {
            string ret = string.Empty;
            foreach (var item in Animals)
            {
                ret += item.ToString() + "\n";
            }
            return ret;
        }

        public World(int x, int y, int z)
        {
            SizeX = x;
            SizeY = y;
            SizeZ = z;
        }

        public void MoveAnimals()
        {

            Random rand = new Random();
            foreach (var animal in Animals)
            {

                int time = rand.Next(2,5);
                Direction dir = (Direction)rand.Next(0,2);

                BackOrForwardHandler handler = x => { if (x == 0) { return 1; } return -1; };

                BackOrForward backOrForward = (BackOrForward)handler(rand.Next(0,1));

                if (animal is Bird)
                {
                    Bird bird = (Bird)animal;
                    if (bird.CanFly)
                    {
                        bird.Fly(time,dir,backOrForward);
                    }
                    else
                    {
                        bird.Walk(time, dir, backOrForward);
                    }
                }
                else
                {
                    Rodent rodent = (Rodent)animal;
                    rodent.Walk(time, dir, backOrForward);
                }
            }
        }

    }   
}

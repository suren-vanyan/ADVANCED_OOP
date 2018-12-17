using OOPBriefing.Animals.Birds;
using OOPBriefing.Foods;
using OOPBriefing.Worlds;
using OOPBriefing.Rudents;
using OOPBriefing.Animals;
using System;
using System.Collections.Generic;

namespace OOPBriefing
{
    class Program
    {
        public static World World;
        static void Main(string[] args)
        {
            Random rnd = new Random();
            World = new World(100, 100, 100);

            var birds = new Bird[]
            {
                new Eagle()
                {
                    Name = "Eagle1111",                  
                    CanFly = true,
                    CanWalk = true,     
                    WalkingSpeed = 2,
                    FlyingSpeed = 15,
                    Wing = new Wing()
                    {
                        WingLength = 15
                    },
                    Feather = new Feather(){
                        Color1 = Misc.Color.Blue,
                        Color2 = Misc.Color.Black
                    },
                    Feather2 = new Feather(){
                        Color2 = Misc.Color.White,
                        Color1 = Misc.Color.Blue
                    }

                },
                new Penguin(){
                    Name = "Penguin11",                    
                    CanFly =false,
                    CanWalk = true,
                    WalkingSpeed = 2,          
                    Wing = new Wing()
                    {
                        WingLength = 2
                    },
                    Feather = new Feather(){
                        Color1 = Misc.Color.Blue,
                        Color2 = Misc.Color.Black
                    }
                },
                new Owl(){
                    Name = "Owl111111",                   
                    CanFly =true,
                    CanWalk = false,
                    FlyingSpeed = 8,
                    Wing = new Wing()
                    {
                        WingLength = 4
                    },
                    Feather = new Feather(){
                        Color1 = Misc.Color.Blue,
                        Color2 = Misc.Color.Black
                    }
                },
                new Falcon()
                {
                    Name = "Falcon111",                   
                    CanFly = true,
                    CanWalk = true,
                    FlyingSpeed = 10,
                    WalkingSpeed = 1,
                    Wing = new Wing()
                    {
                        WingLength = 10
                    },
                    Feather = new Feather(){
                        Color1 = Misc.Color.Blue,
                        Color2 = Misc.Color.Black
                    }
                },
                new Colibri(){
                    Name = "Owl222222",                    
                    CanFly =true,
                    CanWalk = false,
                    FlyingSpeed = 2,                 
                    Wing = new Wing()
                    {
                        WingLength = 1
                    },
                    Feather = new Feather(){
                        Color1 = Misc.Color.Blue,
                        Color2 = Misc.Color.Black
                    }
                }
            };

            World.Animals.AddRange(birds);

            var plants= new Plant[]
            {
                new Plant(), new Plant()
            };
            World.Plants = plants;

            var rudents = new Rudent[]
            {
                new Squirrel()
                {
                    Name = "Squirrel1",
                    Speed = 7,
                    Fur = new Fur()
                    {
                        FurColor = Misc.Color.Black,
                        FurDensity = Density.TypeOne
                    }
                },
                new Rat()
                {
                    Name = "Rat111111",
                    Speed = 6,
                    Fur = new Fur()
                    {
                        FurColor = Misc.Color.Black,
                        FurDensity = Density.TypeTwo
                    }
                },
                new Porcupine(){
                    Name = "Porcupin1",
                    Speed = 2,
                    Fur = new Thorn()
                    {
                        ThornColor = Misc.Color.White,
                        ThornDensity = Density.TypeTwo,
                        ThornLength = 12
                    },
                },
                new Beaver(){
                    Name = "Beaver111",
                    Speed = 4,
                    Fur = new Fur()
                    {
                        FurColor= Misc.Color.Black,
                         FurDensity= Density.TypeThree

                    },
                },

                new Hamster(){
                    Name = "Hamster11",
                    Speed = 2,
                    Fur = new Fur
                    {
                        FurColor= Misc.Color.Blue,
                        FurDensity= Density.TypeTwo,
                    }
                   
                },
            };

            World.Animals.AddRange(rudents);

            Console.WriteLine("before moving on");   
            foreach (var item in World.Animals)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('+',50));
            foreach (var item in World.Animals)
            {
                if(item is Bird bird)
                {
                    if (bird.CanFly == true&&bird.CanWalk==true)
                    {
                        bird.Fly(rnd.Next(1, 7), (Direction)rnd.Next(0, 2), BackOrForward.GoForward);
                        
                    }
                    else if(bird.CanWalk==true && bird.CanFly == false)
                    {
                        bird.Walk(rnd.Next(1, 7), (Direction)rnd.Next(0, 2), BackOrForward.GoForward);
                    }
                    else if (bird.CanWalk == false && bird.CanFly == true)
                    {
                        bird.Fly(rnd.Next(1, 7), (Direction)rnd.Next(0, 2), BackOrForward.GoForward);
                    }
                }
                if(item is Rudent rudent)
                {
                    rudent.Walk(rnd.Next(1, 7), (Direction)rnd.Next(0, 2), BackOrForward.GoForward);
                }
            }
            Console.WriteLine("after direction");  
            foreach (var item in World.Animals)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('+',50));

       







            //List<Animal> animals = myEagle.Watch();
            //Console.WriteLine(animals.Count);
            //foreach (Animal a in animals)
            //{
            //    Console.WriteLine(a.ToString());
            //}

            //animals = mySquirel.Watch();
            //Console.WriteLine("--------------------------------------------");
            //foreach (Animal a in animals) {
            //    Console.WriteLine(a.ToString());
            //}

        }
    }
}

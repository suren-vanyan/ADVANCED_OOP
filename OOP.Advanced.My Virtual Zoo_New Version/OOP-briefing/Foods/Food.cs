using System;

namespace OOPBriefing.Foods 
{
    internal abstract class Food
    {
        public int Energy { get; set; }
        public Food()
        {
            Energy = new Random().Next(25,50);
        }
    }
}

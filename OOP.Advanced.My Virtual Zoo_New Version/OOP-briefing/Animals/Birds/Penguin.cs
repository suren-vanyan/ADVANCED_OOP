using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Animals.Birds
{
    class Penguin : HerbivorousBird
    {
        public Penguin(string name):base(name,true,false)
        {
            OnCreateNewAnimale(this);
        }

        public Penguin():base()
        {

        }
    }
}

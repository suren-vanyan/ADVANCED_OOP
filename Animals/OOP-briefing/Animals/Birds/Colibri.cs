using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Animals.Birds
{
    class Colibri : HerbivorousBird
    {

        public Colibri()
        {

        }

        public Colibri(string name):base(name,true,true)
        {
            OnCreateNewAnimale(this);
        }

    }
}

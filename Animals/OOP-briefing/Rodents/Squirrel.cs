using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Rodents
{
    class Squirrel:Rodent
    {

        public Squirrel():base()
        {

        }

        public Squirrel(string name):base(name)
        {
            OnCreateNewAnimale(this);
        }

    }
}

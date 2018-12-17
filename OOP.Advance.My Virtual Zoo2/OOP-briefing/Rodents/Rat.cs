using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Foods;

namespace OOPBriefing.Rodents
{
    class Rat : Rodent
    {

        public Rat():base()
        {

        }

        public Rat(string name):base(name)
        {
            OnCreateNewAnimale(this);
        }

    }
}

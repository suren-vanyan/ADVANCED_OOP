using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Rodents
{
    class Hamster:Rodent
    {

        public Hamster()
        {

        }
        public Hamster(string name):base(name) { OnCreateNewAnimale(this); }

    }
}

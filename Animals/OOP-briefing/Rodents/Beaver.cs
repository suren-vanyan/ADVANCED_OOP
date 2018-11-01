using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Rodents
{
    class Beaver:Rodent
    {

        public Beaver():base() { }
        public Beaver(string name) : base(name) { OnCreateNewAnimale(this); }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBriefing.Rodents
{
    class Porcupine : Rodent
    {
        public new Thorn Fur { get; set; }

        public Porcupine(string name):base(name)
        {
            Fur = new Thorn();
            OnCreateNewAnimale(this);
        }

        public Porcupine():base()
        {

        }


    }
}

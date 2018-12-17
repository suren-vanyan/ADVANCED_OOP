using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Rodents;

namespace OOPBriefing.Animals.Birds
{
    class Falcon : PredatorBird
    {

        public Falcon(string name):base(name,true,true)
        {
            OnCreateNewAnimale(this);
        }

        public Falcon():base()
        {

        }

        public override Animal Hunt()
        {
            return new Squirrel();
        }
    }
}

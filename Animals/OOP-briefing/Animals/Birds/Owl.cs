using System;
using System.Collections.Generic;
using System.Text;
using OOPBriefing.Rodents;

namespace OOPBriefing.Animals.Birds
{
    class Owl : PredatorBird
    {

        public Owl(string name):base(name,false,true)
        {
            OnCreateNewAnimale(this);
        }

        public Owl():base()
        {

        }

        public override Animal Hunt()
        {
            throw new NotImplementedException();
        }
    }
}

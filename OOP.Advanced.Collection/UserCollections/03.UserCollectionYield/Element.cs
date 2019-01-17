using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UserCollectionYield
{
    public class Element
    {
        public int FieldA { get; set; }
        public int FieldB { get; set; }

        public Element(int fieldA, int fieldB)
        {
            FieldA = fieldA;
            FieldB = fieldB;
        }
    }
}

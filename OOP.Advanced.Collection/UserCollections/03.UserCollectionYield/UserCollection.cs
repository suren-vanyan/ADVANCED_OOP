using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UserCollectionYield
{
    public class UserCollection<T> 
    {
        readonly T[] elements = new T[4];

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

    
        //2.IEnumerator--> Reset
        public void Reset()
        {
            position = -1;
        }


        //4.IEnumerable--> GetEnumerator
       public IEnumerator GetEnumerator()
        {
            while (true)
            {
                if (position < elements.Length - 1)
                {
                    position++;
                    yield return elements[position];
                }
                else
                {
                    Reset();
                    yield  break;
                }
            }

            //foreach (var element in elements)
            //{
            //    yield return element;
            //}

            //return elements.GetEnumerator();
        }

       
    }
}

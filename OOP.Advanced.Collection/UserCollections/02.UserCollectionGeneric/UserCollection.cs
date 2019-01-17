using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.UserCollectionGeneric
{
    public class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        readonly T[] elements = new T[4];

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        //1.IEnumerator--> MoveNext
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        //2.IEnumerator--> Reset
        void IEnumerator.Reset()
        {
            position = -1;
        }

        //3.IEnumerator--> Current
        object IEnumerator.Current
        {
            get { return elements[position]; }
        }

        //3.IEnumerator<T>--> Current
        T IEnumerator<T>.Current =>  elements[position];


        //4.IEnumerable--> GetEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //4.IEnumerable--> GetEnumerator
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        //5.IDisposable-->  Dispose
        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }

      
    }
}

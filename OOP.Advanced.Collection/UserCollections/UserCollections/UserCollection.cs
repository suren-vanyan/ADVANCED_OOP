using System;
using System.Collections;

// Create a simple custom collection.

namespace UserCollections
{
    // A class that represents a custom collection.
    public class UserCollection : IEnumerable, IEnumerator,IDisposable
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;
       
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            //else
            //{
               
            //    (this as IEnumerator).Reset();
            //    return false;
            //}
            return false;
        }
       
        object IEnumerator.Current
        {
            get { return elements[position]; }
        }

       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

 
        void IEnumerator.Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            ((IEnumerator)this).Reset();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;

// create a sample user collection

namespace UserCollections
{
    class Program
    {
        static void Main()
        {

            //Create Collection
            var myCollection = new UserCollection();

            // add 4 item
            myCollection[0] = new Element(1, 2);
            myCollection[1] = new Element(3, 4);
            myCollection[2] = new Element(5, 6);
            myCollection[3] = new Element(7, 8);

            Console.WriteLine("Foreach 1");
           
            foreach (Element element in myCollection)
            {
                Console.WriteLine("{0}, {1}",
                    element.FieldA,
                    element.FieldB);
            }

            Console.WriteLine(new string('-', 5));

 
            Console.WriteLine("Manual 1");

           
            var enumerator = ((IEnumerable)myCollection).GetEnumerator();

            while (enumerator.MoveNext())
            {
                Element element =(Element)enumerator.Current;

                Console.WriteLine("{0}, {1}",element.FieldA,element.FieldB);
            }

            if (myCollection is IDisposable ex)
                   ex.Dispose();

            
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.UserCollectionGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create collection
            UserCollection<Element> сollection = new UserCollection<Element>();

            // Add 4 item
            сollection[0] = new Element(1, 2);
            сollection[1] = new Element(3, 4);
            сollection[2] = new Element(5, 6);
            сollection[3] = new Element(7, 8);

            foreach (var element in сollection)
            {
                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }

            Console.WriteLine(new string('-', 5));

          
            Console.WriteLine("Curstom");
            IEnumerator<Element> enumerator = (сollection as IEnumerable<Element>).GetEnumerator();
            while (enumerator.MoveNext())
            {
                Element element = (Element)enumerator.Current;
                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }

          
            //if (сollection is IDisposable ex)
            //    ex.Dispose();


            Console.WriteLine(new string('-', 5));
            Console.WriteLine("Curstom2");
            IEnumerator<Element> enumerator2 = (сollection as IEnumerable<Element>).GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Element element = (Element)enumerator.Current;
                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }
            Console.ReadKey();
        }
    }
}

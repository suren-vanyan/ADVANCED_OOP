using System;
using System.Reflection;

[assembly: CLSCompliant(true)]
namespace Obsolete
{
 
    public class Winnebago
    {
        public ulong notCompliant;
    }
    class Program
    {
        static void GetListOfAttributes()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);
            MyClass myClass = new MyClass();
            myClass.Method();

            Type t = typeof(MyClass);
            object[] attr = t.GetCustomAttributes(true);
            PrintAttributes(attr);

            MethodInfo memberInfo = t.GetMethod("Method", BindingFlags.Instance | BindingFlags.Public);
            attr = memberInfo.GetCustomAttributes(typeof(MyAttribute), false);
            PrintAttributes(attr);
        }

        static void PrintAttributes(object[] attribute)
        {
            foreach (MyAttribute item in attribute)
            {
                Console.WriteLine($"Number:{item.Number},Date:{item.Date}");
            }
        }

        public static void ReflectOnAttributesUsingEarlyBinding()
        {
           
            Type t = typeof(Motorcycle);
            
            object[] customAtts = t.GetCustomAttributes(false);
          

            foreach (object attr in customAtts)
            {
                if(attr is VehicleDescriptionAttribute e)
                {
                    Console.WriteLine($"{e.TypeId}-> {e.Description}\n");
                }
            }
                

        }
        static void Main()
        {
            //created for scientific purposes only

            OldClass instance = new OldClass();
            instance.ObsoleteMessage();
            // instance.ObsoleteError();
            ReflectOnAttributesUsingEarlyBinding();
            //GetListOfAttributes();




        }
    }
}

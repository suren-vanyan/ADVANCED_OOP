using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CarLibrary;

namespace WorkingWithReflection
{
    class Program
    {
        static void ListMembersOfCar(Type type)
        {
            MemberInfo[] memberInfos = type.GetMembers();

            //Get All members
            foreach (var member in memberInfos)
            {
                Console.WriteLine(member);
            }
        }

        static void ListMembersOfSportCar(SportsCar sportsCar)
        {
            Type type = sportsCar.GetType();
            //Get All Methods from SportsCar
            foreach (var metod in type.GetMethods())
            {
                Console.WriteLine(metod);
            }
            //Get Constructors
            Console.WriteLine(new string('*', 50));
            foreach (ConstructorInfo ctor in type.GetConstructors())
            {
                Console.Write(type.Name + " (");

                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");

            }
        }

        static void ListAllTypesFromAssambley(Assembly assembly)
        {
            Console.WriteLine(assembly.FullName);
            // get all types from assembly Car.Library
            Type[] types = assembly.GetTypes();
            foreach (var item in types)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void ListAllMembers(Assembly assembly)
        {

            // get all types from assembly MiniVan
            Type type = assembly.GetType("CarLibrary.MiniVan");
            Console.WriteLine(type.Name + "=>");
            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }
        static void Main(string[] args)
        {
            Type type = Type.GetType("CarLibrary.Car,Car.Library", false, true);
            ListMembersOfCar(type);
            Console.WriteLine(new string('*', 50));

            SportsCar sportsCar = new SportsCar();
            ListMembersOfSportCar(sportsCar);

            Console.WriteLine("\n");
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("Car.Library");
            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }

            ListAllTypesFromAssambley(assembly);
            Console.WriteLine("\n");
            ListAllMembers(assembly);
        }
    }
}

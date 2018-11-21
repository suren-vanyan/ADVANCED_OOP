using System;

namespace DiffClassAndStruct
{
    class MyClass
    {
        public string chnage;
    }

    struct MyStruct
    {
        public string chnage;
    }
    class Program
    {
        static void ClassTaker(MyClass myClass)
        {
            myClass.chnage = "Changed";
        }

        static void StructTaker(MyStruct myStruct)
        {
            myStruct.chnage = "Changed";
        }
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();
            myClass.chnage = "Not changed";
            Console.WriteLine($"MyClass {myClass.chnage}");
            myStruct.chnage = "Not chnaged";
            Console.WriteLine($"MyStruct {myStruct.chnage}");
            ClassTaker(myClass);
            Console.WriteLine($"after call ClassTaker result is {myClass.chnage}");
            StructTaker(myStruct);
            Console.WriteLine($"after call StructTaker result is {myStruct.chnage}");
        }
    }
}

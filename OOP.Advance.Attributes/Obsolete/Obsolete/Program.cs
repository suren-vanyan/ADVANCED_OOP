using System;

namespace Obsolete
{
    class MyClass
    {
        [Obsolete("Метод устарел")]
        public void ObsoleteMessage()
        {
            Console.WriteLine("Hello world!");
        }

        [Obsolete("Метод не используеться", true)]
        public void ObsoleteError()
        {
            Console.WriteLine("Hello world!");
        }

    }

    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            instance.ObsoleteMessage();

            // instance.ObsoleteError();
        }
    }
}

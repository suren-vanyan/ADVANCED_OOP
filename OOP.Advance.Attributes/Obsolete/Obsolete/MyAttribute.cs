using System;
using System.Collections.Generic;
using System.Text;

namespace Obsolete
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    class MyAttribute : System.Attribute
    {
        private string date;
        public string Date => date;
        public MyAttribute(string date)
        {
            this.date = date;
        }

        public int Number { get; set; }
    }

    [My("26/01/1991", Number = 1)]
    class MyClass
    {
        [My("11/01/1989", Number = 2)]

        [Obsolete("The method is not used", false)]
        public void Method()
        {
            Console.WriteLine("Old method");
        }


    }
}

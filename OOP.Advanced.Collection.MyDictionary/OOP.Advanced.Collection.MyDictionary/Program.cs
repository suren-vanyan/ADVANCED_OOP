using System;

namespace OOP.Advanced.Collection.MyDictionary
{
    class Program
    {     
        public static void BeginTranslate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Please enter a latin word phrase");
            Console.Write("Enter a ");
            while (Console.ReadKey().KeyChar == 'a')
            {
                Console.WriteLine("\n");
                string text = Console.ReadLine();
                string transaltedText = string.Empty;
               text= text.ToLower().TranslateFromEnglishToArmenian(Language.Armenian);
              
                Console.WriteLine(text);
            }
           

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BeginTranslate();
        }
    }
}

using System;

namespace OOP.Advanced.Collection.MyDictionary
{
    class Program
    {
        public static void BeginTranslate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("To translate text \nFrom English to Armenian,press 1" +"\nFrom English to Russian, press 2");
            string text = string.Empty;
            try
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        //From English to Armenian
                        Console.WriteLine("Please enter a English word phrase ");//does not support yet
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromLanguageToLanguage(Language.English);
                        break;              
                    case 2:
                        //From Russian To English
                        Console.WriteLine("Please enter a Russian word phrase ");
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromLanguageToLanguage(Language.Russain);
                        break;
                    default:
                        break;
                }
            }

            catch (Exception e) { throw e; }
            finally { Console.WriteLine(text); }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try { BeginTranslate(); }
            catch (Exception) { }


        }
    }
}

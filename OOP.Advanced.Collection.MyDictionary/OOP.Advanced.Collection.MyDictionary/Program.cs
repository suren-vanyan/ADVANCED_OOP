using System;

namespace OOP.Advanced.Collection.MyDictionary
{
    class Program
    {
        public static void BeginTranslate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
                   
            Console.WriteLine("To translate text \nFrom Armenian to English,press 1 \nFrom English to Armenian,press 2" +
                "\nFrom English to Russian,press 3");
            string text = string.Empty;
            try
            {
                

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        //From Aremnian to English
                        Console.WriteLine("Please enter a Armenian word phrase ");//does not support yet
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromArmenianToEnglish(Language.Armenian);
                        break;
                    case 2:
                        //From English To Armenian
                        Console.WriteLine("Please enter a English word phrase ");
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromEnglishToLanguage(Language.Armenian);
                        break;
                    case 3:
                        //From English To Russian
                        Console.WriteLine("Please enter a English word phrase ");
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromEnglishToLanguage(Language.Russain);
                        break;
                    default:
                        break;
                }
            }
           
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Console.WriteLine(text);
            }
           
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                BeginTranslate();
            }
            catch (Exception)
            {

                
            }
         
        }
    }
}

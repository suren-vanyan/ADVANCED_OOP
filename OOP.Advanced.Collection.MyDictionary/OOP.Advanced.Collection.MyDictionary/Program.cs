using System;

namespace OOP.Advanced.Collection.MyDictionary
{
    class Program
    {
        public static void BeginTranslate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
                   
            Console.WriteLine("To translate text \nFrom Armenian to English,press 1 \nFrom English to Armenian,press 2");
            string text = string.Empty;
            try
            {
                

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Please enter a Armenian word phrase ");
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromEnglishToArmenian(Language.Armenian);
                        break;
                    case 2:
                        Console.WriteLine("Please enter a English word phrase ");
                        text = Console.ReadLine();
                        text = text.ToLower().TranslateFromEnglishToArmenian(Language.Armenian);
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

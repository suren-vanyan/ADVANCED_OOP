using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP.Advance.System.IO.Terminal
{
    static class UniversalTerminal
    {
        private static decimal TotalMoney=500000000;
        private static FileStream file= File.Open("TerminalAmount.text", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        private static StreamWriter writer= new StreamWriter(file);
     
    
        static UniversalTerminal()
        {              
            writer.WriteLine($"{TotalMoney.ToString()} {DateTime.Now}");        
        }

        public static void Put(decimal sum)
        {
            Console.WriteLine($"Client Put {sum} Money");
            TotalMoney += sum;
            using (writer)
            {
                writer.WriteLine($"{TotalMoney.ToString()} {DateTime.Now}");
                          
            }                    
        }

        public static void WithDram(decimal sum)
        {
            TotalMoney -= sum;          
        }
    }
}

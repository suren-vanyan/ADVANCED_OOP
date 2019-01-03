using System;
using System.IO;

namespace OOP.Advance.System.IO.Terminal
{
    class Program
    {
        private static string terminalPath = "TerminalAmount.text";
        private static string userPath = "UserMoney.text";

        public static void PrintCurrentBalance(string path)
        {

            using (StreamReader reader = new StreamReader(path))
            {
                Console.WriteLine("For check the balance enter 1 \nFor check all transfers enter 2");
                string check = Console.ReadLine();

                string temp = string.Empty;
                if (check == "1")
                {
                    while ((temp = reader.ReadLine()) != null)
                    {
                        
                        if (reader.Peek() == -1)
                            Console.WriteLine($"Balance is {temp}");
                    }
                }
                else if (check == "2")
                {
                    while ((temp = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"{temp}");
                    }
                }

            }
        }



        public static void WriteBalance(string path, User user)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine($"{user.Money} {DateTime.Now}");
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo("D:\\");
            User user = new User() { FistName = "Bill", LastName = "Gates", Money = 100000M, Age = 63 };
            Console.WriteLine($"{user.FistName} have a {user.Money:C2}");
           
            try
            {
                WriteBalance(userPath, user);
                Console.WriteLine($"{user.FistName} is looking for a terminal");
                //imagine that the user is looking for a terminal
                // FindDirectory(directory);

                //Client Put Money
                UniversalTerminal.Put(5000);

                PrintCurrentBalance(terminalPath);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
           


        }

        //Վանիկի ասած խնդիրը
        static void FindDirectory(DirectoryInfo directoryinfo)
        {
            foreach (DirectoryInfo directoryItem in directoryinfo.GetDirectories())
            {
                try
                {
                    Console.WriteLine($"FullName:{directoryItem.FullName}");
                    Console.WriteLine($"CreationTime {directoryItem.CreationTime}");

                    foreach (var item in directoryItem.GetFiles())
                    {
                        Console.WriteLine($"FullName {item.FullName}");
                        Console.WriteLine($"Attributes {item.Attributes}");
                        Console.WriteLine($"CreationTime {item.CreationTime}");

                        if (item.Name == "TerminalAmount.text" || item.Name == "UserMoney.text")
                        {
                            //UniversalTerminal.Put(5000);
                            //UniversalTerminal.WithDram(4000);

                            return;
                        }

                    }

                    Console.WriteLine(new string('+', 30));
                    FindDirectory(directoryItem);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine(new string('+', 30));
                }


            }
        }
    }
}

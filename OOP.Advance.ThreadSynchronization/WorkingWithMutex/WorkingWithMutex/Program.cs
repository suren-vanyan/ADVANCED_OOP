using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexExample
{
    class Program
    {
        static List<string> listOne = new List<string> { "Troelsen", "Hovo", "Tom", "Bil", "Vazgen", "Ashot", "Rob" };
        static List<string> ListTwo = new List<string> { "Jon", "Ben", "Pol", "Karen", "Artur", "Ashot", "Poxos" };
        static Mutex tMutex = new Mutex(false, "Toilet");
        static int x = 0;
        static void Main(string[] args)
        {


            Thread[] teamOne = new Thread[7];
            Thread[] teamTwo = new Thread[7];
            for (int i = 0; i < 7; i++)
            {

                teamOne[i] = new Thread(RunningTrackOne);
                teamTwo[i] = new Thread(RunningTrackTwo);
                teamOne[i].Name = listOne[i].ToString();
                teamTwo[i].Name = ListTwo[i].ToString();
               

            }

            for (int i = 0; i < 7; i++)
            {
              //  Thread.Sleep(500);
                teamOne[i].Start();
                teamTwo[i].Start();

            }

            Console.ReadLine();
        }

        static void RunningTrackOne()
        {
            tMutex.WaitOne();
            string threadName = Thread.CurrentThread.Name;
            if (listOne.Contains(threadName))
                listOne.Remove(threadName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Thread.CurrentThread.Name} Started");
            Thread.Sleep(10);
            Console.WriteLine($"{Thread.CurrentThread.Name} Finished");
            if (listOne.Count == 0)
            {

                Console.WriteLine("First team finished");
                Console.ResetColor();

            }

            tMutex.ReleaseMutex();
        }

        static void RunningTrackTwo()
        {

            tMutex.WaitOne();
            string threadName = Thread.CurrentThread.Name;
            if (ListTwo.Contains(threadName))
                ListTwo.Remove(threadName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Thread.CurrentThread.Name} Started");
            Thread.Sleep(10);

            Console.WriteLine($"{Thread.CurrentThread.Name} Finished");
            if (ListTwo.Count == 0)
            {

                Console.WriteLine("Second team finished");
                Console.ResetColor();
            }

            tMutex.ReleaseMutex();
        }


    }
}

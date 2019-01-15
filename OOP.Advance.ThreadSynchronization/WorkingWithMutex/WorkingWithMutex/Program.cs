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
       
        static Mutex tMutex = new Mutex(false,"Mutex");
        static Semaphore semaphore;
        static void Main(string[] args)
        {
            //Thread[] teamOne = new Thread[7];
            //for (int i = 0; i < teamOne.Length; i++)
            //{
            //    teamOne[i] = new Thread(RunningTrackOne);
            //    teamOne[i].Name = listOne[i].ToString();
            //    // Thread.Sleep(500);
            //    teamOne[i].Start();
            //}

            //Console.ReadKey();
            semaphore =new Semaphore(2, 4, "Semafore");

            for (int i = 0; i < 7; i++)
            {
                new Thread(RunningTrackTwo).Start(listOne[i]);
            }
            Console.ReadLine();
        }

        static void RunningTrackOne()
        {
            tMutex.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} Started");
            Thread.Sleep(200);
            Console.WriteLine($"{Thread.CurrentThread.Name} Finished");
            tMutex.ReleaseMutex();         
        }

        static void RunningTrackTwo(object name)
        {
            semaphore.WaitOne();
            Console.WriteLine($"{name} Started");
            Thread.Sleep(300);
            Console.WriteLine($"{name} Finished");
          
            semaphore.Release();
        }
    }
}

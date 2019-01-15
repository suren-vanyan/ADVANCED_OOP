using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkingWithThreadTask1
{
    class Program
    {

        private static int m_flag = 0;
        private static int m_value = 0;
        private static int _stop;

        static void Main(string[] args)
        {
            //optimization is required Properties -optimize code 

            //Thread thread = new Thread(Thread1);
            //Thread thread2 = new Thread(Thread2);
            //thread.Start();
            //thread2.Start();

            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(2000);
            //_stop = 1;
            //These are special methods that disable optimization
            Thread.VolatileWrite(ref _stop, 1);
            Console.WriteLine("Main: waiting for worker to stop");
            thread.Join();

        }

        public static void Thread1()
        {

            m_value = 5;
            Volatile.Write(ref m_flag, 1);

        }

        public static void Thread2()
        {

            if (Volatile.Read(ref m_flag) == 1)
                Console.WriteLine(m_value);
        }

        static void Function()
        {
            int x = 0;
            while (Volatile.Read(ref _stop) != 1)
            {
                x++;
            }
            //while (_stop != 1)
            //{
            //    x++;
            //}
            Console.WriteLine($"Thread Abort when x={x}");
        }
    }
}

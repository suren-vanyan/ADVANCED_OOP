using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceMonitoring
{
    class MemoryMonitoring
    {
        public  readonly int memoryLimitGen1= 84987;
        public readonly int memoryLimitGen2 = 84988;
     
        public void IsMemoryFull(object erorMessage)
        {
            if (memoryLimitGen2 < GC.GetTotalMemory(false))
            {
                
                Console.WriteLine($"{erorMessage}");
                Console.WriteLine($"TotalMemory{GC.GetTotalMemory(false)}");
                Console.WriteLine($"Object was created in Generation :{GC.GetGeneration(this)}");
            }
        }      
    }

    class SmallObject
    {
        int[] array = new int[100]; 

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
    }

    class BigObject
    {
        byte[] array = new byte[84988];

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
    }

    
    class Program
    {
        public static void TestForBigObj()
        {
            BigObject[] bigObjects = new BigObject[200];

            for (int i = 0; i < bigObjects.Length; i++)
            {
                new BigObject().Method(i);

            }
        }

        public static void TestForSmallObj()
        {
            SmallObject[] array = new SmallObject[100];

            for (int i = 0; i < array.Length; i++)
            {
                new SmallObject().Method(i);

            }
        }
        static void Main(string[] args)
        {
            TimerCallback timerCallback = new TimerCallback(new MemoryMonitoring().IsMemoryFull);
            Timer timer = new Timer(timerCallback, new OutOfMemoryException().Message, 0, 200);
            
            TestForSmallObj();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ShowGCStat();
            // Parallel.Invoke(TestForSmallObj,TestForBigObj);

            Console.ReadKey();
        }

        private static void ShowGCStat()
        {
            Console.WriteLine("Generation 0 tested 8 times", GC.CollectionCount(0));
            Console.WriteLine("Generation 1 tested 8 times", GC.CollectionCount(1));
            Console.WriteLine("Generation 1 tested 8 times", GC.CollectionCount(2));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceMonitoring
{
    class MemoryMonitoring
    {
        public  readonly int memoryLimitGen1= 84987;
        public readonly int memoryLimitGen2 = 84988;

        //public MemoryMonitoring(int memoryLimitg1,int memoryLimitg2)
        //{
        //    this.memoryLimitGen1 = memoryLimitg1;
        //    this.memoryLimitGen2 = memoryLimitg2;

        //}

        public void IsMemoryFull(object erorMessage)
        {
            if (memoryLimitGen1 == GC.GetTotalMemory(false))
            {
                Console.WriteLine($"{erorMessage}");
            }
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback timerCallback = new TimerCallback(new MemoryMonitoring().IsMemoryFull);
            Timer timer = new Timer(timerCallback, new OutOfMemoryException().Message, 0, 2000);
            
        }
       
    }
}

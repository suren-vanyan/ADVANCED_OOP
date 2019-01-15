using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VolatileExample2
{
   
    public class Worker
    {    
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
       
        private volatile bool _shouldStop=false;
    }

    public class WorkerThreadExample
    {
        public static void Main()
        {           
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

           
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

           
          //  while (!workerThread.IsAlive) ;
              
                Thread.Sleep(1);

            
            workerObject.RequestStop();

          
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GetDataFromUrlUsingAsyncAwait
{
    class Program
    {     
  
        static void PrintDataResult(GitHubUser hubUser)
        {
            Console.WriteLine($"User Name:{hubUser.name}");

        }

        static void CompletedTask()
        {

        }
        static void Main(string[] args)
        {
            string Url = "https://api.github.com/users/suren-vanyan";

            WebBrowser webBrowser = new WebBrowser();
            HttpBrowser httpBrowser = new HttpBrowser();
            Console.WriteLine("How do you want to download,select client to download data?");

         

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            
           
           
            try
            {
                var firstTask = Task.Run(() => webBrowser.GetDataFromUrlAsync(Url, cancellationToken));
                cancellationTokenSource.Cancel();
                firstTask.Wait();
                if (firstTask.IsCompleted)
                {
                    PrintDataResult(firstTask.Result);
                   
                }
            }
            catch(AggregateException ag)
            {
                Console.WriteLine(ag.Message+$"\nInnerException:{ag.InnerException}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:"+ ex);
            }
            
        }

    
    }
}
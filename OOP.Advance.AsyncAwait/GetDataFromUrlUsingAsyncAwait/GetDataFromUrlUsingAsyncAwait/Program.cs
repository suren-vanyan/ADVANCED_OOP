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
            
            WebBrowser webBrowser = new WebBrowser();
            HttpBrowser httpBrowser = new HttpBrowser();
            Console.WriteLine("How do you want to download,select client to download data?");

            string Url = "https://api.github.com/users/suren-vanyan";
            var firstTask = Task.Run(() => webBrowser.GetDataFromUrlAsync(Url));
            Console.WriteLine(firstTask.Result);
            try
            {
                firstTask.Wait();
                if (firstTask.IsCompleted)
                {
                    PrintDataResult(firstTask.Result);
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:"+ ex);
            }
            
        }

    
    }
}
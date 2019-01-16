using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetDataFromURLAsynchronously
{
    class Program
    {
        static string GetDataFromURL(object url)
        {
            Thread.Sleep(6000);
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(url as string);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  

            Task<WebResponse> taskResponse = request.GetResponseAsync();
            // Display the status.  
            WebResponse response = taskResponse.Result;
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server. 

            string responseFromServer = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                responseFromServer = reader.ReadToEnd();
            }

            return responseFromServer;
        }

        public static string GetDataFromURL2(object urlAddress)
        {
            Thread.Sleep(6000);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress as string);
            Task<WebResponse> task = Task.Factory.FromAsync(
            request.BeginGetResponse,
            asyncResult => request.EndGetResponse(asyncResult),
            (object)null);

            WebResponse webResponse = task.Result;
            HttpWebResponse response = (HttpWebResponse)webResponse;
            string data = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {

                using (Stream receiveStream = response.GetResponseStream())
                using (StreamReader readStream = new StreamReader(receiveStream))
                {
                    data = readStream.ReadToEnd();
                }

            }
            return data;

        }

        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/comments";

            Task<string> firstTaskResult = new Task<string>(GetDataFromURL, url);
            firstTaskResult.Start();
            GetDataIsCompleted(firstTaskResult);
            if (firstTaskResult.IsCompleted)
            {
                Console.WriteLine($"First Task is Completed:{firstTaskResult.IsCompleted}");
                Console.WriteLine(firstTaskResult.Result);
                firstTaskResult.Dispose();

            }

            firstTaskResult.Wait();
            //when the first task is executed another task starts which does the same
            Task<string> secondTaskresult = Task.Factory.StartNew(GetDataFromURL2, url);
            GetDataIsCompleted(secondTaskresult);

            if (secondTaskresult.IsCompleted)
                Console.WriteLine(secondTaskresult.Result);

            Task.WaitAll(firstTaskResult);


        }

        static void GetDataIsCompleted<T>(Task<T> task)
        {
            while (!task.IsCompleted)
            {
                Console.ForegroundColor = (ConsoleColor)new Random().Next(1, 15);
                Console.WriteLine("\t \t\t Hello");
                Console.WriteLine("\t \t Greetings dear programmers");
                Console.WriteLine("\t----The task of this project is to look for data---\n\t ---on and return the result asynchronously---" +
                    "\n\t\t     Waiting for an answer");
                Thread.Sleep(200);
                Console.Clear();
            }
        }
    }
}

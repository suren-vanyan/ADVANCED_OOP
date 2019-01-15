using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetDataFromURLAsynchronously
{
    class Program
    {
        static Task<string> GetDataFromURL(string url)
        {

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  

            ////Task<WebResponse> task = Task.Factory.FromAsync(
            ////   request.BeginGetResponse,
            ////   asyncResult => request.EndGetResponse(asyncResult),
            ////   (object)null);
           
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
            
            return new Task<string>(new Func<string>(()=>responseFromServer));
        }

        public static string GetDataFromURL2(string urlAddress)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream);
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }

            return data;
        }

        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/comments";         
            Task<string> taskResult = GetDataFromURL(url);
            taskResult.Start();
            Console.WriteLine(taskResult.Result);
            taskResult.Wait();
            
            // Console.WriteLine(GetDataFromURL2(url));
        }

       
    }
}

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

namespace GetDataFromUrlUsingAsyncAwait
{
   

    class Program
    {
        static string GetDataFromURL(object url)
        {
            var webRequest = WebRequest.Create(url as string) as HttpWebRequest;

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {


                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    return contributorsAsJson;
                }
            }

        }

        static async Task<string> StartGetDataFromUrl(string Url)
        {
            return await Task<string>.Factory.StartNew(GetDataFromURL, Url);

        }

        static async Task<string> CallGetDataUsingHttp(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    //  response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string stringResponse = await response.Content.ReadAsStringAsync();
                        return stringResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        static void Main(string[] args)
        {
            string Url = "https://api.github.com/users/vanhakobyan";

            //var firstTask = Task.Run(() => StartGetDataFromUrl(Url));
            //Console.WriteLine(firstTask.Result);
            //firstTask.Wait();

            Task<string> secondTask = Task.Run(() => CallGetDataUsingHttp(Url));

            Console.WriteLine(secondTask.Result);

            secondTask.Wait();

            //// Task.WaitAll(firstTask, secondTask);
            // Console.ReadLine();
            //try

        }


    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GetJsonData
{
    class Program
    {       
        public static async void Run(string url, CancellationToken cToken)
        {
           var content= await Task.Run(() => Call.GetDataAsync(url, cToken));
            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(content);
        }

        static void Main(string[] args)
        {
            string url = "https://www.itjobs.am/api/v1.0/companies";
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = new CancellationToken();
            Task task= Task.Run(() => Run(url, token));
            try
            {
                task.Wait();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
        }
    }
}

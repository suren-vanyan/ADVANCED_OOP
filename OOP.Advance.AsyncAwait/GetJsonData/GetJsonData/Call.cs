using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetJsonData
{
    public static class Call
    {
        public static async Task<string> GetDataAsync(string url, CancellationToken cToken)
        {          
            string stringResponse = null;
            try
            {
                if (cToken.IsCancellationRequested)
                {
                    Console.WriteLine("Operation aborted in Method GetDataAsync");
                    cToken.ThrowIfCancellationRequested();
                }

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine();
                    stringResponse = await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stringResponse;
        }

    }
}

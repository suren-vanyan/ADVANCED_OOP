using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetDataFromUrlUsingAsyncAwait
{
    class HttpBrowser
    {
        public GitHubUser DeserializeDataFromUrl(string content, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted by Desrerializing Data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }

            GitHubUser gitHubUser = null;
            try
            {
                gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(content);
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return gitHubUser;
        }

        public async Task<object> GetDataUsingHttpAsync(string url, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted in Method GetDataUsingHttpAsync while receiving data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }
            GitHubUser deserializeResult = null;

            try
            {              
                using (var client = new HttpClient())
                {
                   // client.BaseAddress = new Uri("https://api.github.com");
                    client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync(url).Result;
                   
                    if (response.IsSuccessStatusCode)
                    {
                        string stringResponse = await response.Content.ReadAsStringAsync();
                        deserializeResult = await Task.Run(() => DeserializeDataFromUrl(stringResponse, cToken));
                    }
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return deserializeResult;
        }



        public List<Repository> DeserializeRepoFromUrl(string content, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted by Desrerializing Data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }

            List<Repository> gitHubUser = null;
            try
            {
                gitHubUser = JsonConvert.DeserializeObject<List<Repository>>(content);
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return gitHubUser;
        }
    }
}

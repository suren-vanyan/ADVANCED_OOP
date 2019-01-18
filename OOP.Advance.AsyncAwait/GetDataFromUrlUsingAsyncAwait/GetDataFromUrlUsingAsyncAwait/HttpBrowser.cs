using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<GitHubUser> GetDataUsingHttpAsync(string url, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted in Method GetDataUsingHttpAsync while receiving data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }
            GitHubUser deserializeResult = null;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://api.github.com/users/suren-vanyan");
                    httpClient.DefaultRequestHeaders.Add(
                        "Authorization",
                        "token 123456789307d8c1d138ddb0848ede028ed30567");
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    
                    var response = await httpClient.GetAsync(new Uri(url));
                    //  response.EnsureSuccessStatusCode();

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    string stringResponse = await response.Content.ReadAsStringAsync();
                    //     deserializeResult = await Task.Run(() => DeserializeDataFromUrl(stringResponse, cToken));
                    //}
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return deserializeResult;
        }



        public Repository DeserializeRepoFromUrl(string content, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted by Desrerializing Data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }

            Repository gitHubUser = null;
            try
            {
                gitHubUser = JsonConvert.DeserializeObject<Repository>(content);
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return gitHubUser;
        }
    }
}

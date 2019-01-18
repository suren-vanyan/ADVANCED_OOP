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
                return gitHubUser;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<GitHubUser> GetDataUsingHttpAsync(string url, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted in Method GetDataUsingHttpAsync while receiving data using HttpClient");
                cToken.ThrowIfCancellationRequested();
            }

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));
                    //  response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string stringResponse = await response.Content.ReadAsStringAsync();
                        object deserializeResult = await Task.Run(() => DeserializeDataFromUrl(stringResponse, cToken));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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
                return gitHubUser;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetDataFromUrlUsingAsyncAwait
{
    class WebBrowser
    {
        public GitHubUser DeserializeDataFromUrl(string content, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted by Desrerializing");
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


        public async Task<GitHubUser> GetDataFromUrlAsync(string Url, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Operation aborted by token");
                cToken.ThrowIfCancellationRequested();
            }


            try
            {
                var getDataResult = await Task.Run(() => GetDataFromURL(Url, cToken));

                GitHubUser deserializeResult = await Task.Run(() => DeserializeDataFromUrl(getDataResult, cToken));

                return deserializeResult;

            }
            catch (ArgumentNullException arg) { throw arg; }
            catch (NullReferenceException nr) { throw nr; }
            catch (AggregateException ag) { throw ag; }

        }

        public string GetDataFromURL(string url, CancellationToken cToken)
        {
            try
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
            catch (WebException wb)
            {
                throw wb;
            }

        }
    }
}

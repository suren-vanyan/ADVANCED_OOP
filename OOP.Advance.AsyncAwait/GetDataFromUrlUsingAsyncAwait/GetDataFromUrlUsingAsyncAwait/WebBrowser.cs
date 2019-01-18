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
            GitHubUser gitHubUser = null;
            try
            {
                if (cToken.IsCancellationRequested)
                {
                    Console.WriteLine("Operation aborted by Desrerializing");
                    cToken.ThrowIfCancellationRequested();
                }

                gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(content);
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return gitHubUser;
        }


        public async  Task<string> GetDataFromUrlAsync(string url, CancellationToken cToken)
        {
            string dataResult = string.Empty;
          
            try
            {
                if (cToken.IsCancellationRequested)
                {
                    Console.WriteLine(" Operation aborted in method GetDataFromUrlAsync");
                    cToken.ThrowIfCancellationRequested();
                }

                  dataResult= await Task.Run(() => GetDataFromURL(url, cToken));
                                  
            }
            catch (ArgumentNullException arg) { Console.WriteLine(arg.Message); }
            catch (NullReferenceException nr) { Console.WriteLine(nr.Message); }
            catch (AggregateException ag) { Console.WriteLine(ag.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return dataResult;
        }

        public string GetDataFromURL(string url, CancellationToken cToken)
        {
            string contributorsAsJson = string.Empty;
            try
            {
                if (cToken.IsCancellationRequested)
                {
                    Console.WriteLine("Operation aborted by token,in method GetDataFromURL");
                    cToken.ThrowIfCancellationRequested();
                }

                var webRequest = WebRequest.Create(url as string) as HttpWebRequest;
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";

                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                         contributorsAsJson = sr.ReadToEnd();
                       
                    }
                }
            }
            catch (WebException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return contributorsAsJson;
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
                return gitHubUser;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

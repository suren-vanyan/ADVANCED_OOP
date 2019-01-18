using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetDataFromUrlUsingAsyncAwait
{
    class WebBrowser
    {
        public GitHubUser DeserializeDataFromUrl(object content)
        {
            string result = content as string;
            if (result != null)
            {
                GitHubUser gitHubUser = null;
                try
                {
                    gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(result);
                    return gitHubUser;
                }
                catch (Exception ex) { throw ex; }
            }
            else
            {
                throw new NullReferenceException();
            }
         
        }

        public async Task<GitHubUser> GetDataFromUrlAsync(string Url)
        {
            try
            {
                var getDataResult= await Task<string>.Factory.StartNew(GetDataFromURL, Url);
              GitHubUser deserializeResult=  await Task<GitHubUser>.Factory.StartNew(DeserializeDataFromUrl, getDataResult);

                return deserializeResult;

            }
            catch (ArgumentNullException arg) { throw arg; }
            catch(NullReferenceException nr) { throw nr; }
            catch (AggregateException ag) { throw ag; }

        }

        public string GetDataFromURL(object url)
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

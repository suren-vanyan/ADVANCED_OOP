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
using Newtonsoft.Json;

namespace GetDataFromUrlUsingAsyncAwait
{
    class Program
    {

        static void PrintDataResult(GitHubUser hubUser )
        {         
            Console.WriteLine($"User Name:{hubUser.name}");
            Console.WriteLine($"Country:{hubUser.location}");
            Console.WriteLine($"Number Of Public Repo:{hubUser.public_repos}");
            Console.WriteLine($"Followings: { hubUser.following}");
            Console.WriteLine($"Followers: { hubUser.followers}");
            Console.WriteLine(hubUser.repos_url);
        }

        static void PrintRepo(List<Repository> repositories)
        {
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.name);
            }
        }

     
        //  this method creates a task to use WebClient
        public async static void WebStartUpAsync(string Url, CancellationToken cancellationToken)
        {
            WebBrowser webBrowser = new WebBrowser();

            try
            {
                var data = await Task.Run(() => webBrowser.GetDataFromUrlAsync(Url, cancellationToken));

                var deserialize = await Task.Run(() => webBrowser.DeserializeDataFromUrl(data, cancellationToken));
                PrintDataResult(deserialize);

                GitHubUser hubUser = deserialize as GitHubUser;
                var dataofRepository = await Task.Run(() => webBrowser.GetDataFromUrlAsync(hubUser.repos_url, cancellationToken));

                var deserializeRepository = await Task.Run(() => webBrowser.DeserializeRepoFromUrl(dataofRepository, cancellationToken));
                Console.WriteLine($"{hubUser.name } has a {hubUser.public_repos} public repositories");
                PrintRepo(deserializeRepository);

            }
            catch (ArgumentNullException arg) { Console.WriteLine(arg.Message); }
            catch (AggregateException ag)
            {
                Console.WriteLine(ag.Message + $"\nInnerException:{ag.InnerException}");
            }
            catch (Exception ex){Console.WriteLine("Exception:" + ex);}
        }

     
        static void Main(string[] args)
        {
            string Url = "https://api.github.com/users/suren-vanyan";
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Console.WriteLine("Input <1> for WebRequest Or <2> for HttpClient  to download data ");
            bool result = int.TryParse(Console.ReadLine(),out int input);//Console.ReadLine();
            if (!result) Console.WriteLine("Wrong input Try again");
            try
            {     
                switch (input)
                {
                    case 1:WebStartUpAsync(Url, cancellationToken);break;
                    case 2: HttpStartUpAsync(Url, cancellationToken);break;
                    default: break;
                }
                Thread.Sleep(1000);
               // cancellationTokenSource.Cancel();
            }
            catch (Exception e) { Console.WriteLine(e); }
            Console.ReadLine();
        }

       
        //  this method creates a task to use WebClient
        public async static void HttpStartUpAsync(string Url, CancellationToken cancellationToken)
        {
            HttpBrowser httpBrowser = new HttpBrowser();

            try
            {
                var firstTask = await Task.Run(() => httpBrowser.GetDataUsingHttpAsync(Url, cancellationToken));
                PrintDataResult(firstTask);
            }
            catch (ArgumentNullException arg) { Console.WriteLine(arg.Message); }
            catch (AggregateException ag)
            {
                Console.WriteLine(ag.Message + $"\nInnerException:{ag.InnerException}");
            }
            catch (Exception ex) {Console.WriteLine("Exception:" + ex);}
        }

    }
}
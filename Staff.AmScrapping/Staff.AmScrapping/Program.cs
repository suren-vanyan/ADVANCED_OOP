using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Staff.AmScrapping
{
    class Program
    {
        public static void WriteExceptionInFile(Exception e)
        {
            using (FileStream fileStream = new FileStream("exception.txt", FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(e);

            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // string urlForSearchAllActiveJobs = "https://staff.am/en/jobs?JobsFilter%5Bkey_word%5D=&JobsFilter%5Bcategory%5D=&JobsFilter%5Bcategory%5D%5B%5D=1&JobsFilter%5Bjob_type%5D=&JobsFilter%5Bjob_term%5D=&JobsFilter%5Bjob_city%5D=&JobsFilter%5Bjob_package%5D=&JobsFilter%5Bsort_by%5D=";          
            //List<ActiveJobs> activeJobs=  ActiveJobsParser.SearchAllActiveJob(urlForSearchAllActiveJobs);
            Queue<string> status = new Queue<string>();

            string urlForSearchAllCompanies = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";
            var allActiveJobsTask = Task.Run(() => CompanyParser.SearchAllCompaniesAsync(urlForSearchAllCompanies,status));

            Console.Clear();
            //while (!allActiveJobsTask.IsCompleted)
            //{
            //    if(status.Dequeue()!=null)
            //        Console.WriteLine(status.Dequeue());
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.Write(".");

            //        Thread.Sleep(500);
            //    }
            //    Console.Clear();
            //}

            List<Company> allActiveJobs1 = allActiveJobsTask.Result;

            Console.ReadKey();
          
            //CompanyParser.GetDescritionForJob("https://staff.am/en/software-engineer-php-oriented-1");
        }
    }
}
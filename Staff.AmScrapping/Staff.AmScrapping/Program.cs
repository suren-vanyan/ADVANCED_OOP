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

        public static void Loading(Task task)
        {
           
            while (!task.IsCompleted)
            {
                Console.Clear();
                Console.Write("Loading");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");

                    Thread.Sleep(500);
                }
                Console.Clear();
            }
        }
        public static void PrintFullInformationForCompanies(List<Company> companies)
        {
            Random random = new Random();
            foreach (var company in companies)
            {
                Console.ForegroundColor =(ConsoleColor)random.Next(1, 15);
                Console.WriteLine(company);
                Console.WriteLine(new string('*', 40));
                company.jobDescriptions.ForEach(item => 
                {
                    Console.ForegroundColor = (ConsoleColor)random.Next(1, 15);
                    Console.WriteLine(item);
                    Console.WriteLine(new string('*',40));
                } );
            }
        }
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // string urlForSearchAllActiveJobs = "https://staff.am/en/jobs?JobsFilter%5Bkey_word%5D=&JobsFilter%5Bcategory%5D=&JobsFilter%5Bcategory%5D%5B%5D=1&JobsFilter%5Bjob_type%5D=&JobsFilter%5Bjob_term%5D=&JobsFilter%5Bjob_city%5D=&JobsFilter%5Bjob_package%5D=&JobsFilter%5Bsort_by%5D=";          
            //List<ActiveJobs> activeJobs=  ActiveJobsParser.SearchAllActiveJob(urlForSearchAllActiveJobs);
           

            string urlForSearchAllCompanies = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";
            var taskForFindAllCompanies = Task.Run(() => CompanyParser.SearchURLForAllCompaniesAsync(urlForSearchAllCompanies));

           
            Loading(taskForFindAllCompanies);

            List<Company> companies = taskForFindAllCompanies.Result;
            PrintFullInformationForCompanies(companies);
            Console.ReadKey();

           
        }
    }
}
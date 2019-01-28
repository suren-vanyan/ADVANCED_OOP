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

namespace JobFinderScrapping
{
    class Program
    {
        public static void SearchActiveJob()
        {
            string url = "https://staff.am/en/jobs?JobsFilter%5Bkey_word%5D=&JobsFilter%5Bcategory%5D=&JobsFilter%5Bcategory%5D%5B%5D=1&JobsFilter%5Bjob_type%5D=&JobsFilter%5Bjob_term%5D=&JobsFilter%5Bjob_city%5D=&JobsFilter%5Bjob_package%5D=&JobsFilter%5Bsort_by%5D=";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            string job = "//div[@class=\"job-inner job-item-title\"]";
           
            string job2 = "//div[@class='job-inner job-list-deadline']";
            HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes(job);
            HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes(job2);
            List<ActiveJobs> activeJobs = new List<ActiveJobs>();
            for (int i = 0; i < jobItemTitle.Count; i++)
            {
                string[] splitText = jobItemTitle[i].InnerText.Split('\n');
                string[] splitText2 = jobԼistDeadline[i].InnerText.Split('\n');
                string temp = splitText2[3] + splitText2[4] + splitText2[5];
                activeJobs.Add(new ActiveJobs { JobName = splitText[1], CompanyName = splitText[2],Data=temp});
            }

            foreach (var item in activeJobs)
            {
                Console.WriteLine($"Company:{item.CompanyName},Data:{item.Data},Job:{item.JobName}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            //SearchActiveJob();
            string url = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";
            Helper.ScrapForStaffAM(url);

            Console.ReadKey();
            HtmlWeb web = new HtmlWeb();

            string directory = @"C:\Users\suren\source\repos\HTMLScrapping\HTMLScrapping\bin\Debug\netcoreapp2.1";
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--disable-images");
            ChromeDriver chromeDriver = new ChromeDriver(directory, co);

            chromeDriver.Navigate().GoToUrl(url);
            //for (int i = 0; i < 10; i++)
            //{
            //    try
            //    {
            //        chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
            //    }
            //    catch (Exception e)
            //    {

            //    }
            //    Thread.Sleep(1000);
            //}

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(chromeDriver.PageSource);

           
        }
    }
}
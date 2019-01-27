using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Get_Companies_From_WebSite
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string url = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";

            HtmlWeb web = new HtmlWeb();

            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--disable-images");
           
            string directory = @"C:\Users\suren\source\repos\HTMLScrapping\HTMLScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory,co);
           
            chromeDriver.Navigate().GoToUrl(url);
            for (int i = 0; i < 80; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
                }
                catch (Exception e)
                {

                }
               
            }

        

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(chromeDriver.PageSource);
         
            string className2 = "//div[@class=\"company-action company_inner_right\"]";


           
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className2);
           
            List<string> compURLList = new List<string>();
            foreach (HtmlNode node in nodes)
            {
                Thread.Sleep(50);
                string href = node.InnerHtml;
                var splited = href.Split(' ')[1];
                var urlcomp = splited.Substring(6, splited.Length - 7);
                compURLList.Add(@"https://staff.am" + urlcomp);
            }

            string l = compURLList[0];

            HtmlDocument htmlDoc = web.Load(l);
            string companyProperties = "//p[@class=\"professional-skills-description\"]";
            HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

            Company company_1 = new Company(htmlNodes[0].InnerText, htmlNodes[1].InnerText, htmlNodes[2].InnerText, htmlNodes[3].InnerText, htmlNodes[4].InnerText, htmlNodes[5].InnerText);

            string companyName = "//h1[@class=\"text-left\"]";
            HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);
            company_1.Name = htmlNodeOfName[0].InnerText;


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"This is main information about {company_1.Name}.");
            Console.ForegroundColor = ConsoleColor.Gray;
            company_1.DescribeYourself();

            Console.ReadKey();
        }
    }
}
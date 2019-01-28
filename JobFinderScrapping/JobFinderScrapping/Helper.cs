using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JobFinderScrapping
{
    public static class Helper
    {
        public static void ToScroll(ChromeDriver chromeDriver)
        {
           
            for (int i = 0; i < 80; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
                }
                catch (Exception e)
                {
                    Program.WriteExceptionInFile(e.Message);
                }
                Thread.Sleep(1500);
            }
        }

        public static void SearchActiveJob(string url)
        {          
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
                activeJobs.Add(new ActiveJobs { JobName = splitText[1], CompanyName = splitText[2], Data = temp });
            }

            foreach (var item in activeJobs)
            {
                Console.WriteLine($"Company:{item.CompanyName},Data:{item.Data},Job:{item.JobName}");
            }
            Console.ReadLine();
        }

        public static List<Company> ScrapForStaffAM(string url)
        {
            //HtmlWeb web = new HtmlWeb();
           // HtmlDocument doc = web.Load(url);

            string className2 = "//div[@class=\"company-action company_inner_right\"]";

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"C:\Users\suren\source\repos\HTMLScrapping\HTMLScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory,chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);
           // ToScroll(chromeDriver);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(chromeDriver.PageSource);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className2);
            List<string> compURLList = new List<string>();
            try
            {
                foreach (HtmlNode node in nodes)
                {
                    string href = node.InnerHtml;
                    var splited = href.Split(' ')[1];
                    var urlcomp = splited.Substring(6, splited.Length - 7);
                    compURLList.Add(@"https://staff.am" + urlcomp);
                }
            }
            catch (Exception e)
            {
                Program.WriteExceptionInFile(e);
            }
            

            List<Company> allCompanies = new List<Company>();
            foreach (var compURL in compURLList)
            {
                chromeDriver.Navigate().GoToUrl(compURL);
                // ToScroll(chromeDriver);

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(chromeDriver.PageSource);

                string companyProperties = "//p[@class=\"professional-skills-description\"]";
                HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

                string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                string textAboutComp = htmlNodesAboutComp[0].InnerText.Replace("\n", "");

                string companyName = "//h1[@class=\"text-left\"]";
                HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);

                Company company = new Company();

               
                try
                {
                    company.Name = htmlNodeOfName[0].InnerText;
                    company.Industry = htmlNodes[0].InnerText;
                    company.Type = htmlNodes[1].InnerText;
                    company.NumbOfEmployees = htmlNodes[2].InnerText;
                    company.DataOfFoundation = htmlNodes[3].InnerText;
                    company.WebSite = htmlNodes[4].InnerText;
                    company.Adress = htmlNodes[5].InnerText;
                    company.AboutCompany = textAboutComp;
                }
                catch (ArgumentException arg)
                {
                    Program.WriteExceptionInFile(arg);
                }
           
                allCompanies.Add(company);
                company.DescribeYourself();
                Thread.Sleep(4000);
                Console.Clear();

            }
            return allCompanies;
        }
    }
}

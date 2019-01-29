using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace JobFinderScrapping
{
    public static class CompanyParser
    {
        public static string Scroll(string url)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ADVANCE_OOP\Staff.AmScrapping\Staff.AmScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
                }
                catch (Exception e)
                {
                    Program.WriteExceptionInFile(e);
                }
                Thread.Sleep(2000);
            }

            //long scrollHeight = 0;
            //do
            //{
            //    IJavaScriptExecutor js = chromeDriver;
            //    var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

            //    if (newScrollHeight == scrollHeight)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        scrollHeight = newScrollHeight;
            //        Thread.Sleep(2000);
            //    }
            //} while (true);

            return chromeDriver.PageSource;
        }

        public static List<ActiveJobs> SearchActiveJobForCompany(HtmlDocument doc)
        {


            //HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes("//div[@class=\"job-inner job-item-title\"]");
            //HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes("//div[@class='job-inner job-list-deadline']");
            //HtmlNodeCollection jobLocation = doc.DocumentNode.SelectNodes("//div[@class='job-inner job-location']");
            //for (int i = 0; i < jobItemTitle.Count; i++)
            //{
            //    var location = jobLocation[i].InnerText.Replace(" ", "").Replace("\n", "");
            //    var names = (jobItemTitle[i].InnerText.Replace(" ", "").Split('\n')
            //    .Select(item => item.Replace("\r", ""))).ToArray();

            //    var data = jobԼistDeadline[i].InnerText.Replace(" ", "").Split('\n')
            //                .Select(item => item.Replace("\r", ""))
            //                .Where(item => !string.IsNullOrEmpty(item)).ToArray();

            //    ActiveJobs activeJobs = new ActiveJobs
            //    {
            //        CompanyJobName = names[1],
            //        CompanyName = names[2],
            //        JobData = string.Join(" ", data),
            //        Location = location
            //    };

            //    allActiveJobs.Add(activeJobs);
            //}


            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='col-sm-6 pl5']");
            List<string> activeJobsUrlList = new List<string>();
            foreach (HtmlNode node in nodes)
            {
               
                var jobUrl = node.SelectSingleNode(".//a").Attributes[1].Value;
                activeJobsUrlList.Add(@"https://staff.am" + jobUrl);                  
            }


            List<ActiveJobs> allActiveJobs = new List<ActiveJobs>();

           

            return allActiveJobs;
        }

        public static List<Company> SearchAllCompanies(string url)
        {
          
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Scroll(url));

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class=\"company-action company_inner_right\"]");
            List<string> companyUrlList = new List<string>();
            try
            {
                foreach (HtmlNode node in nodes)
                {
                    var jobUrl = node.SelectSingleNode(".//a").Attributes[0].Value;
                    companyUrlList.Add(@"https://staff.am" + jobUrl);
                  
                }
            }
            catch (Exception e)
            {
                Program.WriteExceptionInFile(e);
            }

            List<Company> allCompanies = new List<Company>();
            foreach (var companyUrl in companyUrlList)
            {
                Company company = new Company();

                try
                {

                    HtmlDocument htmlDoc = htmlWeb.Load(companyUrl);

                    company.ActiveJobs = SearchActiveJobForCompany(htmlDoc);

                    string companyProperties = "//p[@class=\"professional-skills-description\"]";
                    // string companyProperties = "//div[@class='professional-skills-description']";                 
                    HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

                    string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                    HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                    var textAboutComp = htmlNodesAboutComp.Select(i => i.InnerText.Replace("\n", "")).ToList();


                    string companyName = "//h1[@class=\"text-left\"]";
                    HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);


                    List<string> nodeInnerText = htmlNodes.Select(node => node.InnerText.Replace("\n", "").ToLower()).ToList();
                    foreach (var innerText in nodeInnerText)
                    {
                        if (innerText.Contains("industry")) company.Industry = innerText;
                        if (innerText.Contains("type")) company.Type = innerText;
                        if (innerText.Contains("number of employees")) company.NumbOfEmployees = innerText;
                        if (innerText.Contains("foundation")) company.DataOfFoundation = innerText;
                        if (innerText.Contains("website")) company.WebSite = innerText;
                        if (innerText.Contains("address")) company.Adress = innerText;

                    }

                    List<string> nodeofName = htmlNodeOfName.Select(item => item.InnerText).ToList();
                    if (nodeofName != null) company.Name = nodeofName[0];
                    if (textAboutComp != null) company.AboutCompany = textAboutComp[0];




                }
                catch (ArgumentException arg) { Program.WriteExceptionInFile(arg); }
                catch (Exception e) { Program.WriteExceptionInFile(e); }

                allCompanies.Add(company);
                Console.WriteLine(company);
                Console.WriteLine("Active Jobs=>");
                company.ActiveJobs.ForEach(item => Console.WriteLine(item));
                Thread.Sleep(8000);
                Console.Clear();

            }

            return allCompanies;
        }
    }
}

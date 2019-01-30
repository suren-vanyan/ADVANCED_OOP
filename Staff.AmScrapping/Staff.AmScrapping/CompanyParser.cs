using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Staff.AmScrapping
{
    public class CompanyParser
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

       public static JobDescription GetDescritionForJob(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb.Load(url);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='job-post']");
            
           

            JobDescription job = new JobDescription();
            foreach (var node in nodes)
            {
                var baseNodeInfo = node.Descendants("div").Where(item=>item.GetAttributeValue("class","").Equals("col-lg-6 job-info")).ToList();
                var empTermCategory = baseNodeInfo[0].Descendants("p").Select(item => item.InnerText).ToList();
                job.EmploymentTerm = empTermCategory[0];
                job.Category = empTermCategory[1];
                var typeAndLocation = baseNodeInfo[1].Descendants("p").Select(item => item.InnerText).ToList();
                job.Type = typeAndLocation[0];
                job.Location = typeAndLocation[1];
                job.JobName = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='col-lg-8']/h2[1]").InnerText;
                job.Deadline = node.SelectSingleNode("//div[@class='col-lg-4 apply-btn-top']/p[1]").InnerText.Replace("\n", "");

                //job.Category = node.SelectNodes("//div[@class='col-lg-6 job-info']/p[2]").FirstOrDefault().InnerText.Trim('\r','\n','\t');
                job.Description = node.SelectSingleNode("//div[@class='job-list-content-desc']/p").InnerText.Trim('\r', '\n', '\t');
                job.JobResponsibilities = node.SelectSingleNode("//div[@class='job-list-content-desc']/p[2]").InnerText.Trim('\r', '\n', '\t');
                job.RequiredQualifications = node.SelectSingleNode("//div[@class='job-list-content-desc']/p[3]").InnerText.Trim('\r', '\n', '\t');
            }

            return job;
        }

        public static List<JobDescription> SearchActiveJobForCompany(HtmlDocument doc)
        {

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='col-sm-6 pl5']");
            List<string> activeJobsUrlList = new List<string>();
            foreach (HtmlNode node in nodes)
            {

                var jobUrl = node.SelectSingleNode(".//a").Attributes[1].Value;
                activeJobsUrlList.Add(@"https://staff.am" + jobUrl);
            }


            List<JobDescription> allActiveJobs = new List<JobDescription>();
            foreach (var url in activeJobsUrlList)
            {
                allActiveJobs.Add(GetDescritionForJob(url));
            }




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

                    company.jobDescriptions = SearchActiveJobForCompany(htmlDoc);

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
               // Console.WriteLine("Active Jobs=>");
                //company.ActiveJobs.ForEach(item => Console.WriteLine(item));
               // Thread.Sleep(8000);
                Console.Clear();

            }

            return allCompanies;
        }
    }
}

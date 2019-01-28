using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JobFinderScrapping
{
    public static class Helper
    {
        public static string Scroll(string url)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ADVANCE_OOP\JobFinderScrapping\JobFinderScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            for (int i = 0; i < 20; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
                }
                catch (Exception e)
                {
                    Program.WriteExceptionInFile(e);
                }
                Thread.Sleep(1000);
            }
            return chromeDriver.PageSource;
        }

        public static List<ActiveJobs> SearchActiveJob(string url)
        {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Scroll(url));

            string path1 = "//div[@class=\"job-inner job-item-title\"]";

            string path2 = "//div[@class='job-inner job-list-deadline']";

            HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes(path1);
            HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes(path2);

            List<ActiveJobs> allActiveJobs = new List<ActiveJobs>();

            for (int i = 0; i < jobItemTitle.Count; i++)
            {

                var names = (jobItemTitle[i].InnerText.Replace(" ", "").Split('\n')
                .Select(item => item.Replace("\r", ""))).ToArray();

                var data = jobԼistDeadline[i].InnerText.Replace(" ", "").Split('\n')
                            .Select(item => item.Replace("\r", ""))
                            .Where(item => !string.IsNullOrEmpty(item)).ToArray();


                allActiveJobs.Add(new ActiveJobs { JobName = names[1], CompanyName = names[2], Data = string.Join("", data) });
            }

            return allActiveJobs;
        }

        public static List<Company> ScrapForStaffAM(string url)
        {
            string className2 = "//div[@class=\"company-action company_inner_right\"]";

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Scroll(url));

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className2);
            List<string> companyUrlList = new List<string>();
            try
            {
                foreach (HtmlNode node in nodes)
                {
                    string href = node.InnerHtml;
                    var splited = href.Split(' ')[1];
                    var urlcomp = splited.Substring(6, splited.Length - 7);
                    companyUrlList.Add(@"https://staff.am" + urlcomp);
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
                    string companyProperties = "//p[@class=\"professional-skills-description\"]";
                    // string companyProperties = "//div[@class='professional-skills-description']";                 
                    HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

                    string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                    HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                    var textAboutComp =htmlNodesAboutComp.Select(i=>i.InnerText.Replace("\n", "")).ToList(); 
                   

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

                    //company.Industry = htmlNodes[0].InnerText;
                    //company.Type = htmlNodes[1].InnerText;
                    //company.NumbOfEmployees = htmlNodes[2].InnerText;
                    //company.DataOfFoundation = htmlNodes[3].InnerText;
                    //company.WebSite = htmlNodes[4].InnerText;
                    //company.Adress = htmlNodes[5].InnerText;
                    //company.Name = htmlNodeOfName[0].InnerText;

                }
                catch (ArgumentException arg) { Program.WriteExceptionInFile(arg); }
                catch (Exception e) { Program.WriteExceptionInFile(e); }

                allCompanies.Add(company);
                company.DescribeYourself();
                Thread.Sleep(4000);
                Console.Clear();

            }
            return allCompanies;
        }
    }
}

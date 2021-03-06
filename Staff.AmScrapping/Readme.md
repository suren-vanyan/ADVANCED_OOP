# **_This project is looking for all the companies on the Staff.am website, as well as all the works that offer this companies_**
![staff am gif](https://user-images.githubusercontent.com/38188753/51933414-b7a05b00-241a-11e9-984c-7004fbe2ee9f.gif)

```c#
 public static string Scroll(string url)
        {
           
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ADVANCE_OOP\Staff.AmScrapping\Staff.AmScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            //if you want to select all 240 companies remove comments
            //and put comments on the top loop

            long scrollHeight = 0;
            do
            {
                IJavaScriptExecutor js = chromeDriver;
                var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {

                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(2000);
                }
            } while (true);

            string returnVaule = chromeDriver.PageSource;
            chromeDriver.Close();
            
            return returnVaule;
        }
```

```c#
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Staff.AmScrapping
{
    public class CompanyParser
    {

        /// <summary>
        /// this method finds all active jobs and returns their full description.
        /// </summary>
        /// <param name="url>"For Example=> https://staff.am/en/software-engineer-php-oriented-1""</param>
        /// <returns> JobDescription</returns>
        public static JobDescription GetDescritionForJob(string url)
        {

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb.Load(url);
           
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='job-post']");
            JobDescription job = new JobDescription();
            try
            {
                foreach (var node in nodes)
                {
                    var baseNodeInfo = node.Descendants("div").Where(item => item.GetAttributeValue("class", "").Equals("col-lg-6 job-info")).ToList();
                    var empTermCategory = baseNodeInfo[0].Descendants("p").Select(item => item.InnerText.Trim('\r', '\n', '\t')).ToList();
                    job.EmploymentTerm = empTermCategory[0];
                    job.Category = empTermCategory[1];
                    var typeAndLocation = baseNodeInfo[1].Descendants("p").Select(item => item.InnerText.Trim('\r', '\n', '\t')).ToList();
                    job.Type = typeAndLocation[0];
                    job.Location = typeAndLocation[1];
                    job.JobName = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='col-lg-8']/h2[1]").InnerText.Trim('\r', '\n', '\t');
                    job.Deadline = node.SelectSingleNode("//div[@class='col-lg-4 apply-btn-top']/p[1]").InnerText.Replace("\n", "");

                    //job.Category = node.SelectNodes("//div[@class='col-lg-6 job-info']/p[2]").FirstOrDefault().InnerText.Trim('\r','\n','\t');
                    job.Description = node.SelectSingleNode("//div[@class='job-list-content-desc']/p").InnerText.Trim('\r', '\n', '\t');
                    job.JobResponsibilities = node.SelectSingleNode("//div[@class='job-list-content-desc']/p[2]").InnerText.Trim('\r', '\n', '\t');
                    job.RequiredQualifications = node.SelectSingleNode("//div[@class='job-list-content-desc']/p[3]").InnerText.Trim('\r', '\n', '\t');
                }
            }
            catch (Exception e) { Program.WriteExceptionInFile(e); }


            return job;
        }



        /// <summary>
        /// In this Method First we find all the links to active works.
        /// after, we call the method GetDescritionForJob to which we transfer the reference to the work
        /// which in turn finds all active jobs and returns their full description.
        /// </summary>
        /// <param name="doc">HtmlDocument</param>
        /// <returns> List<JobDescription></returns>
        public static List<JobDescription> SearchActiveJobsURLForCompany(HtmlDocument doc)
        {

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='col-sm-6 pl5']");
            List<string> activeJobsUrlList = new List<string>();


            try
            {
                //find all links to active work
                foreach (HtmlNode node in nodes)
                {

                    var jobUrl = node.SelectSingleNode(".//a").Attributes[1].Value;
                    activeJobsUrlList.Add(@"https://staff.am" + jobUrl);
                }

            }
            catch (Exception) { }


            List<JobDescription> allActiveJobs = new List<JobDescription>();
            foreach (var url in activeJobsUrlList)
            {
                //call the method for Example:url="https://staff.am/en/software-engineer-php-oriented-1"
                allActiveJobs.Add(GetDescritionForJob(url));
            }

            return allActiveJobs;
        }


        public static async Task<List<Company>> SearchURLForAllCompaniesAsync(string url)
        {
            return await Task.Run(() => SearchURLForAllCompanies(url));

        }


        /// <summary>
        /// At the beginning using the scroll method finds all companies the maximum number is 240
        /// Then we find the address of a particular company
        /// </summary>
        /// <param name="url">https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=</param>
        /// <returns> List<Company> </returns>
        public static List<Company> SearchURLForAllCompanies(string url)
        {
            
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            //if you want to select all 240 companies remove comments  Method Scroll      
            doc.LoadHtml(Scrolling.Scroll(url));
            List<Company> allCompanies = null;

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class=\"company-action company_inner_right\"]");
            List<string> companyUrlList = new List<string>();
            try
            {
                // find the address of a particular company
                foreach (HtmlNode node in nodes)
                {
                    var jobUrl = node.SelectSingleNode(".//a").Attributes[0].Value;
                    companyUrlList.Add(@"https://staff.am" + jobUrl);

                }

                allCompanies = GetAllCompaniesWithTheirJobs(companyUrlList);
            }
            catch (Exception e) { Program.WriteExceptionInFile(e); }
           
            return allCompanies;
        }


        /// <summary>
        /// This method calls the SearchActiveJobsURLForCompany method which in turn finds all the active work for a particular company.
        /// then finds a description of the company
        /// </summary>
        /// <param name="companyUrlList">List<string> For example:compnayURL="https://staff.am/en/company/betconstruct"</param>
        /// <returns>List<Company></returns>
        public static List<Company> GetAllCompaniesWithTheirJobs(List<string> companyUrlList)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            List<Company> allCompanies = new List<Company>();
            foreach (var companyUrl in companyUrlList)
            {
                Company company = new Company();

                try
                {
                    // For example:compnayURL="https://staff.am/en/company/betconstruct"
                    HtmlDocument htmlDoc = htmlWeb.Load(companyUrl);


                    company.jobDescriptions = SearchActiveJobsURLForCompany(htmlDoc);

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
            }

            return allCompanies;
        }
    }
}
```

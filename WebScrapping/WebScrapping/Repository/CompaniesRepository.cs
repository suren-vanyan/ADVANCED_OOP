using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapping.Models;

namespace WebScrapping.Repository
{
    public class CompaniesRepository
    {
        public static List<Company> SearchURLForAllCompanies(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();

            //if you want to select all 240 companies remove comments  Method Scroll      
            // doc.LoadHtml(Scrolling.Scroll(url));

            
            doc = htmlWeb.Load(url);
            List<Company> allCompanies = null;

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='company-action company_inner_right']");
            List<string> companyUrlList = new List<string>();
            try
            {
                // find the address of a particular company
                foreach (HtmlNode node in nodes)
                {
                    var jobUrl = node.SelectSingleNode(".//a").Attributes[0].Value;
                    companyUrlList.Add(@"https://staff.am" + jobUrl);

                }

                allCompanies = GetAllCompaniesWithTheirInfo(companyUrlList);
            }
            catch (Exception ) { }

            return allCompanies;
        }

        public static List<Company> GetAllCompaniesWithTheirInfo(List<string> companyUrlList)
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
                catch (Exception ) {  }

                allCompanies.Add(company);
            }

            return allCompanies;
        }
    }
}

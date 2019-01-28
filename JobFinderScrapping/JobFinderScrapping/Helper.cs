using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JobFinderScrapping
{
    public static class Helper
    {
        public static List<Company> ScrapForStaffAM(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            string className2 = "//div[@class=\"company-action company_inner_right\"]";

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
                Console.WriteLine(e.Message);
            }
            

            List<Company> allCompanies = new List<Company>();
            foreach (var compURL in compURLList)
            {
                HtmlDocument htmlDoc = web.Load(compURL);
                string companyProperties = "//p[@class=\"professional-skills-description\"]";
                HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties);

                string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                string text = htmlNodesAboutComp[0].InnerText.Replace("\n", "");

                string companyName = "//h1[@class=\"text-left\"]";
                HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);

                Company company_1 = new Company();

               
                try
                {
                    company_1.Name = htmlNodeOfName[0].InnerText;
                    company_1.Industry = htmlNodes[0].InnerText;
                    company_1.Type = htmlNodes[1].InnerText;
                    company_1.NumbOfEmployees = htmlNodes[2].InnerText;
                    company_1.DataOfFoundation = htmlNodes[3].InnerText;
                    company_1.WebSite = htmlNodes[4].InnerText;
                    company_1.Adress = htmlNodes[5].InnerText;
                    company_1.AboutCompany = text;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"This is main information about {company_1.Name}.");
                Console.ForegroundColor = ConsoleColor.Gray;
                company_1.DescribeYourself();
                allCompanies.Add(company_1);
                Thread.Sleep(4000);
                Console.Clear();

            }
            return allCompanies;
        }
    }
}

using System;
using System.Collections.Generic;

namespace NewHelper
{
    public static void ToScroll(string url)
    {
        ChromeOptions co = new ChromeOptions();
        co.AddArgument("--disable-images");
        string directory = @"C:\Users\ganih\source\repos\Homework_Advanced_C_Sharp\Homework1_JSON\bin\Debug";
        ChromeDriver chromeDriver = new ChromeDriver(directory, co);
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
            Thread.Sleep(1500);
        }
    }
    public static List<Company> ScrapForStaffAM(string url)
    {
        HtmlWeb web = new HtmlWeb();
        ToScroll(url);
        HtmlDocument doc = web.Load(url);
        string className = "//div[@class=\"company-action company_inner_right\"]";
        HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(className);
        List<string> compURLList = new List<string>();  // Create company url list
        foreach (HtmlNode node in nodes)
        {
            string href = node.InnerHtml;
            var splited = href.Split(' ')[1];
            var urlcomp = splited.Substring(6, splited.Length - 7);
            compURLList.Add(@"https://staff.am" + urlcomp); // Fill the company url list
        }
        List<Company> allCompanies = new List<Company>(); // Create company list which will include all companies whith their info
        try
        { // try-i mejinna ,indz tvuma aveli lava senc nayes qan es bacatrem))))))
            foreach (var compURL in compURLList)
            {
                HtmlDocument htmlDoc = web.Load(compURL);
                string companyProperties = "//p[@class=\"professional-skills-description\"]";
                HtmlNodeCollection htmlNodes = htmlDoc.DocumentNode.SelectNodes(companyProperties); // All the property values in a collection 
                List<string> props = new List<string>(6) { "Industry:", "Type:", "Number of employees:", "Data of foundation", "Website:", "Adress:" };
                for (int i = 0; i < htmlNodes.Count; i++)
                {
                    string[] splitedNode = htmlNodes[i].InnerText.Split(' ');
                    bool exists = false;
                    for (int j = 0; j < props.Count; j++)
                    {
                        if (splitedNode[0] == props[j])
                        {
                            props[i] = htmlNodes[i].InnerText;
                            exists = true;
                            break;
                        }
                    }
                    if (exists == false)
                    {
                        props[i] = null;
                    }
                }
                Company company = new Company(props[0], props[1], props[2], props[3], props[4], props[5]);
                string companyProp = "//div[@class='col-lg-8 col-md-8 about-text']";
                HtmlNodeCollection htmlNodesAboutComp = htmlDoc.DocumentNode.SelectNodes(companyProp);
                string text = htmlNodesAboutComp[0].InnerText.Replace("\n", "");
                company.AboutCompany = text; // Find text about company
                string companyName = "//h1[@class=\"text-left\"]";
                HtmlNodeCollection htmlNodeOfName = htmlDoc.DocumentNode.SelectNodes(companyName);
                company.Name = htmlNodeOfName[0].InnerText; // Find company name
                allCompanies.Add(company);  // Add company to the list
            }
        }
        catch (Exception e)
        {
            Program.WriteExceptionInFile(e.Message);
        }  // u arhasarak inchqan exception unenanq vortex unenanq karelia grel static methodi mej, nerqevuma WriteExceptionInFile

        return allCompanies;
    }
}

}

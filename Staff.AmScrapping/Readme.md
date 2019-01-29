# **_This project is looking for all the companies on the Staff.am website, as well as all the works that offer this companies_**
![staff am gif](https://user-images.githubusercontent.com/38188753/51933414-b7a05b00-241a-11e9-984c-7004fbe2ee9f.gif)

```c#
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

            return chromeDriver.PageSource;
        }

        public static List<ActiveJobs> SearchActiveJobForCompany(HtmlDocument doc)
        {

            string pathForNames = "//div[@class=\"job-inner job-item-title\"]";

            string pathForData = "//div[@class='job-inner job-list-deadline']";
            string pathForLoacation = "//div[@class='job-inner job-location']"; 
            
            HtmlNodeCollection jobItemTitle = doc.DocumentNode.SelectNodes(pathForNames);
            HtmlNodeCollection jobԼistDeadline = doc.DocumentNode.SelectNodes(pathForData);
            HtmlNodeCollection jobLocation = doc.DocumentNode.SelectNodes(pathForLoacation);

            List<ActiveJobs> allActiveJobs = new List<ActiveJobs>();

            for (int i = 0; i < jobItemTitle.Count; i++)
            {
                var location = jobLocation[i].InnerText.Replace(" ", "").Replace("\n", "");
                var names = (jobItemTitle[i].InnerText.Replace(" ", "").Split('\n')
                .Select(item => item.Replace("\r", ""))).ToArray();

                var data = jobԼistDeadline[i].InnerText.Replace(" ", "").Split('\n')
                            .Select(item => item.Replace("\r", ""))
                            .Where(item => !string.IsNullOrEmpty(item)).ToArray();


                allActiveJobs.Add(new ActiveJobs { CompanyJobName = names[1], CompanyName = names[2], JobData = string.Join(" ", data), Location =location });
            }

            return allActiveJobs;
        }

        public static List<Company> SearchAllCompanies(string url)
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

                 company.ActiveJobs=  SearchActiveJobForCompany(htmlDoc);

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
```

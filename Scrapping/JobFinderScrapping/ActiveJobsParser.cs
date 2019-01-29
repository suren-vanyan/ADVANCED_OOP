using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JobFinderScrapping
{
    class ActiveJobsParser
    {
        public static string Scroll(string url)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ADVANCE_OOP\Scrapping\JobFinderScrapping\bin\Debug\netcoreapp2.1";
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

            //for (int i = 0; i < 20; i++)
            //{
            //    try
            //    {
            //        chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
            //    }
            //    catch (Exception e)
            //    {
            //        Program.WriteExceptionInFile(e);
            //    }
            //    Thread.Sleep(1000);
            //}
            return chromeDriver.PageSource;
        }

        public static List<ActiveJobs> SearchAllActiveJob(string url)
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


                allActiveJobs.Add(new ActiveJobs { CompanyJobName = names[1], CompanyName = names[2], JobData = string.Join("", data) });
            }

            return allActiveJobs;
        }
    }
}

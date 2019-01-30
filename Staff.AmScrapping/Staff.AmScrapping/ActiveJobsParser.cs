using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Staff.AmScrapping
{
    class ActiveJobsParser
    {
       
        public static List<ActiveJobs> SearchAllActiveJob(string url)
        {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Scrolling.Scroll(url));

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

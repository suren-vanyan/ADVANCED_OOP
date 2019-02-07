using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebScrapping.Models
{
    public class Scrolling
    {
        public static string Scroll(string url)
        {

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-images");
            string directory = @"D:\GitHub_Projects\ADVANCE_OOP\Staff.AmScrapping\Staff.AmScrapping\bin\Debug\netcoreapp2.1";
            ChromeDriver chromeDriver = new ChromeDriver(directory, chromeOptions);
            chromeDriver.Navigate().GoToUrl(url);

            for (int i = 0; i < 1; i++)
            {
                try
                {
                    chromeDriver.ExecuteScript($"window.scrollBy(0,1750);");
                }
                catch (Exception) { }
                
                Thread.Sleep(2000);
            }


            //if you want to select all 240 companies remove comments
            //and put comments on the top loop

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

            string returnVaule = chromeDriver.PageSource;
            chromeDriver.Close();

            return returnVaule;
        }
    }
}

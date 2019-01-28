using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JobFinderScrapping
{
    class Program
    {
       

        public static void WriteExceptionInFile(Exception e)
        {
            FileStream fileStream = new FileStream("exception.txt", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(e);
                writer.Flush();
            }            
        }

        internal static void WriteExceptionInFile(string message)
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {           
            string urlForSearchAllCompanies = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";    
            Helper.ScrapForStaffAM(urlForSearchAllCompanies);

            string urlForSearchAllActiveJobs = "https://staff.am/en/jobs?JobsFilter%5Bkey_word%5D=&JobsFilter%5Bcategory%5D=&JobsFilter%5Bcategory%5D%5B%5D=1&JobsFilter%5Bjob_type%5D=&JobsFilter%5Bjob_term%5D=&JobsFilter%5Bjob_city%5D=&JobsFilter%5Bjob_package%5D=&JobsFilter%5Bsort_by%5D=";
            Helper.SearchActiveJob(urlForSearchAllActiveJobs);
    
           

           
        }
    }
}
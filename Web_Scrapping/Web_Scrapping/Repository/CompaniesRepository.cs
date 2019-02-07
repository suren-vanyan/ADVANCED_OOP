using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Scrapping.Models;

namespace Web_Scrapping.Repository
{
    public class CompaniesRepository
    {
        public static List<Companies> GetCompanyList()
        {
            List<Companies> companiesList = new List<Companies>();
            companiesList.Add(new Companies
            {
                Name = "X-Tech",
                Industry = "Informatin texnologies",
                Adress = "Movses Xorenaci",
                Type = "Unknown",
                WebSite = "http://x-tech.am/website",
                AboutCompany = "Unknown"
            });
            return companiesList;
        }
    }
}

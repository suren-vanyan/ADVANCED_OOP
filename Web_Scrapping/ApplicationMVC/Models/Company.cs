using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationMVC.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public string NumbOfEmployees { get; set; }
        public string DataOfFoundation { get; set; }
        public string AboutCompany { get; set; }
        public string WebSite { get; set; }
        public string Adress { get; set; }
    }
}
//public class CompaniesRepository
//{
//    public static List<Companies> GetCompanyList()
//    {
//        List<Companies> companiesList = new List<Companies>();
//        companiesList.Add(new Companies
//        {
//            Name = "X-Tech",
//            Industry = "Informatin texnologies",
//            Adress = "Movses Xorenaci",
//            Type = "Unknown",
//            WebSite = "http://x-tech.am/website",
//            AboutCompany = "Unknown"
//        });
//        return companiesList;
//    }
//}
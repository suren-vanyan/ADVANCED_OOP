using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.AmScrapping
{
    public class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public string NumbOfEmployees { get; set; }
        public string DataOfFoundation { get; set; }
        public string AboutCompany { get; set; }
        public string WebSite { get; set; }
        public string Adress { get; set; }
        // public List<ActiveJobs> ActiveJobs { get; set; }= new List<ActiveJobs>();
        public List<JobDescription> jobDescriptions { get; set; } = new List<JobDescription>();

        public Company(string name, string industry, string type, string numbOfEmployees,
            string dataOfFoundation, string webSite, string adress, string aboutCompany)
        {
            Name = name;
            Industry = industry;
            Type = type;
            NumbOfEmployees = numbOfEmployees;
            DataOfFoundation = dataOfFoundation;
            WebSite = webSite;
            Adress = adress;
            AboutCompany = aboutCompany;

        }

        public Company()
        {

        }

        public override string ToString()
        {
            return $"{Name}\n{Industry}\n{Type}\n{NumbOfEmployees}\n{DataOfFoundation}\n{WebSite}\n{Adress}" +
                $"\n\n{AboutCompany}";
        }

    }
}
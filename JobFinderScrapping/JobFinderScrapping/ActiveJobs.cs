using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinderScrapping
{
    public class ActiveJobs
    {
        public string CompanyJobName { get; set; }
        public string JobData { get; set; }       
        public string CompanyName { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{CompanyJobName}\n{JobData}\n{Location}";
        }
    }
}
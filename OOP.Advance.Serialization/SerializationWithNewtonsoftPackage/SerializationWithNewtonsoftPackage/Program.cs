using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace JSONSerialization
{
    class Program
    {
        public static void Serialization(Company[] company)
        {
           string jsonFormatter= JsonConvert.SerializeObject(company,Formatting.Indented);
            File.WriteAllText("company.json", jsonFormatter);
           
        }

        public static void DeSerialization()
        {

        }
        static void Main(string[] args)
        {         
            Apple apple = new Apple()
            {
                Name = "Apple",
                WEBSITE = "https://www.apple.com/",
                Address = "Cupertino CA 95014",
                Country = "US",
                CITY = "Cupertino",
                Phone= "1-800-275-2273",
               
                Products = new Product[]
                {
                    new Product{ProductName="iPhone XR",Id=1001,Price=449},
                    new Product{ProductName="iPhone XS",Id=2001,Price=699},
                     new Product{ProductName="MacBook Pro",Id=3001,Price=1.299},

                }
            };

            Microsoft microsoft = new Microsoft()
            {
                Name = "Microsoft Corporation",
                WEBSITE = "https://www.microsoft.com/",
                Address = "Redmond, WA 98052-7329",
                Country = "US",
                CITY = "Redmond, Washington",
                Phone = "(425) 882 - 8080",

                Products = new Product[]
                {
                    new Product{ProductName="Windows 10 Pro",Id=101,Price=289},
                    new Product{ProductName="Xbox One X",Id=201,Price=499},
                     new Product{ProductName="Xbox One S",Id=301,Price=299},

                }
            };

            Company[] company = new Company[] { microsoft, apple };

            Serialization(company);
            
        }
    }
}

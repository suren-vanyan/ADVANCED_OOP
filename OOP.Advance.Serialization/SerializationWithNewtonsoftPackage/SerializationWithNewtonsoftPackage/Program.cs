using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace JSONSerialization
{
    class Program
    {
        public static void Serialization(Company[] company,string path)
        {
           string jsonFormatter= JsonConvert.SerializeObject(company,Formatting.Indented);
            using (StreamWriter textWriter=new StreamWriter(path))
            {
                textWriter.Write(jsonFormatter);
            }

          // File.WriteAllText(path, jsonFormatter);
           
        }

        public static void DeSerialization(string path)
        {
            //approach 1
            string[] jsoonCompany=  File.ReadAllLines(path);
            foreach (var item in jsoonCompany)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            //does the same as the  version before
            //approach 2
            using (StreamReader reader=new StreamReader(path))
            {
                string line = string.Empty;
                while ((line=reader.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
            }
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
            string filePath = "company.json";
            Serialization(company,filePath);//this method serialize an object
            DeSerialization(filePath);//this method deserializes the object

        }
    }
}

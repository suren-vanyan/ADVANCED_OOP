using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONSerialization
{
    class Program
    {

        public static void firstSerializationApproach(List<Company> companies, string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(path))
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonTextWriter, companies);
            }
        }

        public static void firstDeSerializationApproach(string path)
        {
            List<Company> companies = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader(path))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                companies = serializer.Deserialize<List<Company>>(jsonReader);
            }

            foreach (Company company in companies)
            {

                Print(company);
                Console.WriteLine(new string('*', 50));
            }

        }


        public static void secondSerializationApproach(List<Company> companies, string path)
        {
            //string jsonFormatter = JsonConvert.SerializeObject(companies, Formatting.Indented);

            string jsonFormatter = JsonConvert.SerializeObject(companies, Formatting.Indented,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(path, jsonFormatter);
        }


        public static void secondDeSerializationApproach(string path)
        {
            string jsoonCompany = File.ReadAllText(path);
            List<Company> companies = null;

            // companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany);

            companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

          
            foreach (Company company in companies)
            {
                Print(company);
                Console.WriteLine(new string('*', 50));
            }

        }


        public static void GetContentFromJson(string path)
        {
            string jsoonCompany = File.ReadAllText(path);
            JArray jArray = JArray.Parse(jsoonCompany);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (JObject jObject in jArray.Children<JObject>())
            {
                foreach (JProperty jProperty in jObject.Properties())
                {
                    Console.WriteLine(jProperty.Next);  
                }
            }
           
        }


        static void Main(string[] args)
        {
            Company apple = new Company()
            {
                Name = "Apple",
                WEBSITE = "https://www.apple.com/",
                Address = "Cupertino CA 95014",
                Country = "US",
                CITY = "Cupertino",
                Phone = "1-800-275-2273",

                Products = new List<Product>
                {
                    new Product{ProductName="iPhone XR",Id=1001,Price=449},
                    new Product{ProductName="iPhone XS",Id=2001,Price=699},
                     new Product{ProductName="MacBook Pro",Id=3001,Price=1.299},

                }
            };

            Company microsoft = new Company()
            {
                Name = "Microsoft Corporation",
                WEBSITE = "https://www.microsoft.com/",
                Address = "Redmond, WA 98052-7329",
                Country = "US",
                CITY = "Redmond, Washington",
                Phone = "(425) 882 - 8080",

                Products = new List<Product>
                {
                    new Product{ProductName="Windows 10 Pro",Id=101,Price=289},
                    new Product{ProductName="Xbox One X",Id=201,Price=499},
                     new Product{ProductName="Xbox One S",Id=301,Price=299},

                }
            };

            List<Company> companies = new List<Company> { microsoft, apple };
            string filePath = "company.json";

            //firstSerializationApproach(companies, filePath);
            //firstDeSerializationApproach(filePath);

             secondSerializationApproach(companies, filePath);
             secondDeSerializationApproach(filePath);     
             GetContentFromJson(filePath);
             PrintAsJson(filePath);
        }

        public static void PrintAsJson(string path)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('*', 50));
            using (StreamReader reader = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
        }

        public static void Print(Company company)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{company.Name}=>\nCompany Address: {company.Address}" +
                $"\nPhone Number of Company: {company.Phone} ");
            Console.WriteLine("The company has the following products=>");
            foreach (var product in company.Products)
            {
                Console.WriteLine($"ProductName: {product.ProductName}-->Price: {product.Price.ToString("c")}");
            }
        }
    }
}

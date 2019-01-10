using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace JSONSerialization
{
    class Program
    {
        //Serialization approach 2
        public static void Serialization2(List<Company> companies, string path)
        {
           
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(path))
            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonTextWriter, companies);
            }
        }
        // DeSerialization approach 2
        public static void DeSerialization2(string path)
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

        //Serialization approach 1
        public static void Serialization(List<Company> companies, string path)
        {
            string jsonFormatter = JsonConvert.SerializeObject(companies, Formatting.Indented,
            //string jsonFormatter = JsonConvert.SerializeObject(companies, Formatting.Indented);
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Arrays });
            File.WriteAllText(path, jsonFormatter);
      
            //using (StreamWriter textWriter = new StreamWriter(path))
            //{
            //    textWriter.Write(jsonFormatter);
            //}

        }

    
        // DeSerialization approach 1
        public static List<Company> DeSerialization(string path)
        {
            string jsoonCompany = File.ReadAllText(path);
            List<Company> companies = null;
            // companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany);
            companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
         
            foreach (Company company in companies)
            {
                
                Print(company);
                Console.WriteLine(new string('*',50));
            }
   

            //  print as json file contents
            Console.WriteLine(new string('*', 50));
            using (StreamReader reader = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
          
            return companies;
        }

        //կիսատա
        public static void DeserializeSpecificProperty(string path)
        {
            string jsoonCompany = File.ReadAllText(path);
            List<Company> companies = null;
            // companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany);
            companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany,
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            Type[] typeList = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in typeList)
            {
                foreach (var property in type.GetProperties())
                {
                    var propertyAttributes = Attribute.GetCustomAttributes(property);

                    
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
                Phone = "1-800-275-2273",

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

            List<Company> companies = new List<Company> { microsoft, apple };
            string filePath = "company.json";

            Serialization(companies, filePath);//this method serialize an object
            List<Company> newCompanies =  DeSerialization(filePath);//this method deserializes the object

            //Serialization2(companies, filePath);
            // DeSerialization2(filePath);

            DeserializeSpecificProperty(filePath);//կիսատա
        }

        public static void Print(Company company)
        {
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

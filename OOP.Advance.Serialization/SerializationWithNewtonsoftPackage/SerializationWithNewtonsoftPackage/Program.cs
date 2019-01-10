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
        public static void Serialization(List<Company> companies, string path)
        {
            string jsonFormatter = JsonConvert.SerializeObject(companies, Formatting.Indented);
            using (StreamWriter textWriter = new StreamWriter(path))
            {
                textWriter.Write(jsonFormatter);
            }

            File.WriteAllText(path, jsonFormatter);

            //different approach
            //JsonSerializer serializer = new JsonSerializer();
            //using (StreamWriter streamWriter = new StreamWriter(path))
            //using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
            //{
            //    serializer.Serialize(jsonTextWriter, companies);
            //}

        }

        public static List<Company> DeSerialization(string path)
        {
            string jsoonCompany = File.ReadAllText(path);
            List<Company> companies = null;
            
            companies = JsonConvert.DeserializeObject<List<Company>>(jsoonCompany);

            // different approach

            //JsonSerializer serializer = new JsonSerializer();
            //using (StreamReader reader = new StreamReader(path))
            //using (JsonTextReader jsonReader=new JsonTextReader(reader))
            //{
            //    companies = serializer.Deserialize<List<Company>>(jsonReader);
            //}


            //using (StreamReader reader = new StreamReader(path))
            //{
            //    string line = string.Empty;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }

            //}

            return companies;
        }
        public static void Method(string path)
        {

            Type[] typeList = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in typeList)
            {
                foreach (var property in type.GetProperties())
                {
                    var propertyAttributes = Attribute.GetCustomAttributes(property);

                }
            }


            using (var stringReader = new StringReader(path))
            using (var jsonTextReader = new JsonTextReader(stringReader))
            {
                while (jsonTextReader.Read())
                {
                    if (jsonTextReader.TokenType == JsonToken.PropertyName) ;
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
           // Serialization(companies, filePath);//this method serialize an object

             List<Company> newCompanies =  DeSerialization(filePath);//this method deserializes the object

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace JSONSerialization
{
    class Program
    {
        public static void  Serialization(DataContractJsonSerializer serializer,List<Company> companies,string path)
        {
            string serializCompany = string.Empty;
            using (FileStream fS=new FileStream(path,FileMode.OpenOrCreate))
            {
               serializer.WriteObject(fS, companies);
            }
        }

        public static void DeSerialization(DataContractJsonSerializer serializer, string path)
        {
            using (FileStream fs=new FileStream(path,FileMode.OpenOrCreate))
            {
              List<Company> companies=  serializer.ReadObject(fs)as List<Company>;
            }
        }
        static void Main(string[] args)
        {
            Company nike = new Company()
            {
                Name = "Nike",
                WEBSITE = "https://www.nike.com/",
                Address = "Beaverton, OR 97005",
                Country = "US",
                CITY = "Oregon",
                Phone = "1-503-671-6453",
                Products = new Product[]
                {
                    new Product("Nike Air Max 97 QS",10.5,190),
                    new Product("Nike Air VaporMax",11,170),
                    
                }
            };

            Company adidas = new Company()
            {
                Name = "Adidas",
                WEBSITE = "https://www.adidas-group.com/en/",
                Address = "3 Aram Street, Yerevan 0010",
                Country = "Germany",
                CITY = "Herzogenaurach,",
                Phone = "(010) 544707",
                Products = new Product[]
                {
                    new Product("PREDATOR TANGO",13.5,80),
                    new Product("NEMEZIZ",10,275),
                  
                }
            };

            List<Company> listofCompany = new List<Company> { adidas, nike };
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Company>));

            string path = "company.json";
            Serialization(serializer, listofCompany, path);
            DeSerialization(serializer, path);

        }
    }
}

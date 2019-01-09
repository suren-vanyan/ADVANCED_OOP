using System;

namespace JSONSerialization
{
     class Program
    {
        static void Main(string[] args)
        {
            Company apple = new Apple()
            {
                Name = "Apple",
                WEBSITE = "https://www.apple.com/",
                Addres= "Cupertino CA 95014",
                Country="US",
                CITY= "Cupertino",
                Products=new Product[]
                {
                    new Product{ProductName="iPhone XR",Id=1001,Price=449},
                    new Product{ProductName="iPhone XS",Id=2001,Price=699},
                     new Product{ProductName="MacBook Pro",Id=3001,Price=1.299},

                }
            };

            Company microsoft=new Microsoft()
            {
                Name = "Microsoft",
                WEBSITE = "https://www.microsoft.com/",
                Addres = "Cupertino CA 95014",
                Country = "US",
                CITY = "Cupertino",
            }
        }
    }
}

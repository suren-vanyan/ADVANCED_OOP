using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
    class Product
    {
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public double Size { get; set; }
        [DataMember]
        public double Price { get; set; }

        public Product()
        {

        }
        public Product(string name,double size,double price)
        {
            ProductName = name;
            Size = size;
            Price = price;
        }
    }
}

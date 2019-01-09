using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
    class Product
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
    }
}

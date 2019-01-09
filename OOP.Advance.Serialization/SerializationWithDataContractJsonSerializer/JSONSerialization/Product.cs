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
        public int Id { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
     class Company
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string WEBSITE { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string CITY { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public Product[] Products { get; set; }
    }
}

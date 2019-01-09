using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
    abstract class Company
    {
        [DataMember]
        public string Name { get; set; }
        public string WEBSITE { get; set; }
        public string Addres { get; set; }
        public string CITY { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

    }
}

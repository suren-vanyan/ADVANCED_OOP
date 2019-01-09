using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
    class Microsoft:Company
    {
        [DataMember]
        public Product Products { get; set; }
        
    }
}

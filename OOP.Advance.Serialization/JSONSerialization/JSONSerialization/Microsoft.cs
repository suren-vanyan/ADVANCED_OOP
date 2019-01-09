using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONSerialization
{
    [DataContract]
    class Microsoft:Company
    {
        public Product[] Products { get; set; }
        
    }
}

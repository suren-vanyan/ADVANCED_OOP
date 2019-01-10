using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSONSerialization
{

    class Company
    {
        [JsonProperty("Company Name")]
        public string Name { get; set; }

        [JsonProperty("Company WEBSITE")]
        public string WEBSITE { get; set; }

        [JsonProperty("Company Address")]
        public string Address { get; set; }

        [JsonProperty("City of Company")]
        public string CITY { get; set; }

        [JsonProperty("Country of Company")]
        public string Country { get; set; }

        [JsonProperty("Phone Number of Company")]
        public string Phone { get; set; }

        public  List<Product> Products { get; set; }
    }
}

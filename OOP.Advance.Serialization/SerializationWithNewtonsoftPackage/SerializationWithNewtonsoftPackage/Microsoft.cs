using Newtonsoft.Json;

namespace JSONSerialization
{

    class Microsoft:Company
    {
        [JsonProperty("Microsoft company products")]
        public Product[] Products { get; set; }
        
    }
}

using Newtonsoft.Json;

namespace JSONSerialization
{

    class Apple:Company
    {
        [JsonProperty("Apple company products")]
        public Product[] Products { get; set; }
    }
}

using Newtonsoft.Json;

namespace JSONSerialization
{

    class Microsoft:Company
    {
        [JsonProperty("Microsoft company products")]
        public override Product[] Products { get; set; }
        
    }
}

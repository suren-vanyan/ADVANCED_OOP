using Newtonsoft.Json;

namespace JSONSerialization
{
    
    class Product
    {
       [JsonProperty("Product Name")]
        public string ProductName { get; set; }

        [JsonProperty("Product ID")]
        public int Id { get; set; }

        [JsonProperty("Product Price")]
        public double Price { get; set; }
    }
}

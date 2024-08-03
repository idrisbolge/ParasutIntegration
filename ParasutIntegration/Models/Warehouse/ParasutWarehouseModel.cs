using Newtonsoft.Json;
namespace ParasutIntegration.Models.Warehouse
{
    public class ParasutWarehouseModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("is_abroad")]
        public bool IsAbroad { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }
    }

}

using Newtonsoft.Json;

namespace ParasutIntegration.Models.Stock
{
    public class ParasutStockMovementModel
    {
        [JsonProperty("detail_no")]
        public int DetailNo { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}

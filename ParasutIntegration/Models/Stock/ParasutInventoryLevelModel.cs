using Newtonsoft.Json;

namespace ParasutIntegration.Models.Stock
{
    public class ParasutInventoryLevelModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("stock_count")]
        public int StockCount { get; set; }

        [JsonProperty("initial_stock_count")]
        public int InitialStockCount { get; set; }

        [JsonProperty("critical_stock_count")]
        public int CriticalStockCount { get; set; }
    }
}

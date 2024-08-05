using Newtonsoft.Json;

namespace ParasutIntegration.Models.SalesInvoice
{
    public class ParasutSalesInvoicePayResponseModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public decimal Currency { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }

}

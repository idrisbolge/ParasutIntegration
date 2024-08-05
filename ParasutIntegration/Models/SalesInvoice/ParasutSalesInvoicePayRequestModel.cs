using Newtonsoft.Json;

namespace ParasutIntegration.Models.SalesInvoice
{
    public class ParasutSalesInvoicePayRequestModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }
    }

}

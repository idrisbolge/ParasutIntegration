using Newtonsoft.Json;

namespace ParasutIntegration.Models.Company
{
    public class ParasutTransactionModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("amount_in_trl")]
        public decimal AmountInTrl { get; set; }

        [JsonProperty("debit_amount")]
        public decimal DebitAmount { get; set; }

        [JsonProperty("debit_currency")]
        public string DebitCurrency { get; set; }

        [JsonProperty("credit_amount")]
        public decimal CreditAmount { get; set; }

        [JsonProperty("credit_currency")]
        public string CreditCurrency { get; set; }
    }
}

using Newtonsoft.Json;
using ParasutIntegration.Enums;

namespace ParasutIntegration.Models.Account
{
    public class AccountModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currency")]
        public CurrencyEnum Currency { get; set; }

        [JsonProperty("account_type")]
        public AccountTypeEnum AccountType { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bank_branch")]
        public string BankBranch { get; set; }

        [JsonProperty("bank_account_no")]
        public string BankAccountNo { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }
    }
}

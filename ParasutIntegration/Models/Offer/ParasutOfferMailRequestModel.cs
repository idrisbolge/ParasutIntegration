using Newtonsoft.Json;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferMailRequestModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_status")]
        public string EmailStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
    }

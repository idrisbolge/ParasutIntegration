using Newtonsoft.Json;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferMailResponseModel
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_status")]
        public string EmailStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
    }

using Newtonsoft.Json;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferPdfModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("statistics")]
        public string Statistics { get; set; }
    }
}

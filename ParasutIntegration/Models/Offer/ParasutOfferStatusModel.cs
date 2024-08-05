using Newtonsoft.Json;
using ParasutIntegration.Enums;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferStatusModel
    {
        [JsonProperty("status")]
        public OfferStatusEnum Status { get; set; }
    }
}

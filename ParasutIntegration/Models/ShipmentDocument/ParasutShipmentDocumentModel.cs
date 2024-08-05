using Newtonsoft.Json;

namespace ParasutIntegration.Models.ShipmentDocument
{
    public class ParasutShipmentDocumentModel
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("invoice_no")]
        public string InvoiceNo { get; set; }

        [JsonProperty("print_note")]
        public string PrintNote { get; set; }

        [JsonProperty("printed_at")]
        public DateTime PrintedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("inflow")]
        public bool Inflow { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("issue_date")]
        public DateTime IssueDate { get; set; }

        [JsonProperty("shipment_date")]
        public DateTime ShipmentDate { get; set; }

        [JsonProperty("procurement_number")]
        public string ProcurementNumber { get; set; }
    }
}

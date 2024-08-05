using Newtonsoft.Json;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferDetailModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("net_total")]
        public decimal NetTotal { get; set; }

        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("vat_rate")]
        public decimal VatRate { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("discount_value")]
        public decimal DiscountValue { get; set; }

        [JsonProperty("communications_tax_rate")]
        public decimal CommunicationsTaxRate { get; set; }

        [JsonProperty("excise_duty_type")]
        public string ExciseDutyType { get; set; }

        [JsonProperty("invoice_discount")]
        public decimal InvoiceDiscount { get; set; }

        [JsonProperty("excise_duty")]
        public decimal ExciseDuty { get; set; }

        [JsonProperty("excise_duty_rate")]
        public decimal ExciseDutyRate { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        [JsonProperty("communications_tax")]
        public decimal CommunicationsTax { get; set; }

        [JsonProperty("detail_no")]
        public int DetailNo { get; set; }

        [JsonProperty("net_total_without_invoice_discount")]
        public decimal NetTotalWithoutInvoiceDiscount { get; set; }

        [JsonProperty("vat_withholding")]
        public decimal VatWithholding { get; set; }

        [JsonProperty("vat_withholding_rate")]
        public decimal VatWithholdingRate { get; set; }

        [JsonProperty("accommodation_tax_rate")]
        public decimal AccommodationTaxRate { get; set; }

        [JsonProperty("accommodation_tax")]
        public decimal AccommodationTax { get; set; }

        [JsonProperty("accommodation_tax_exempt")]
        public bool AccommodationTaxExempt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("excise_duty_value")]
        public decimal ExciseDutyValue { get; set; }
    }

}

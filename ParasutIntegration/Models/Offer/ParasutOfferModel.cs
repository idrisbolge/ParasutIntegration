using Newtonsoft.Json;

namespace ParasutIntegration.Models.Offer
{
    public class ParasutOfferModel
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("sharings_count")]
        public int SharingsCount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("display_exchange_rate_in_pdf")]
        public bool DisplayExchangeRateInPdf { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("net_total")]
        public decimal NetTotal { get; set; }

        [JsonProperty("gross_total")]
        public decimal GrossTotal { get; set; }

        [JsonProperty("withholding")]
        public decimal Withholding { get; set; }

        [JsonProperty("total_excise_duty")]
        public decimal TotalExciseDuty { get; set; }

        [JsonProperty("total_communications_tax")]
        public decimal TotalCommunicationsTax { get; set; }

        [JsonProperty("total_accommodation_tax")]
        public decimal TotalAccommodationTax { get; set; }

        [JsonProperty("total_vat")]
        public decimal TotalVat { get; set; }

        [JsonProperty("total_vat_withholding")]
        public decimal TotalVatWithholding { get; set; }

        [JsonProperty("vat_withholding")]
        public decimal VatWithholding { get; set; }

        [JsonProperty("total_discount")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("total_invoice_discount")]
        public decimal TotalInvoiceDiscount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("issue_date")]
        public DateTime IssueDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange_rate")]
        public decimal ExchangeRate { get; set; }

        [JsonProperty("withholding_rate")]
        public decimal WithholdingRate { get; set; }

        [JsonProperty("invoice_discount_type")]
        public string InvoiceDiscountType { get; set; }

        [JsonProperty("invoice_discount")]
        public decimal InvoiceDiscount { get; set; }

        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }

        [JsonProperty("billing_fax")]
        public string BillingFax { get; set; }

        [JsonProperty("tax_office")]
        public string TaxOffice { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("is_abroad")]
        public bool IsAbroad { get; set; }

        [JsonProperty("order_no")]
        public string OrderNo { get; set; }

        [JsonProperty("order_date")]
        public DateTime OrderDate { get; set; }
    }

}

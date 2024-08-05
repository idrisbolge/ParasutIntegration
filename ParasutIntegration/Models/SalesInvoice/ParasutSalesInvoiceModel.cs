using Newtonsoft.Json;

namespace ParasutIntegration.Models.SalesInvoice
{
    public class ParasutSalesInvoiceModel
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("invoice_no")]
        public string InvoiceNo { get; set; }

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

        [JsonProperty("total_vat")]
        public decimal TotalVat { get; set; }

        [JsonProperty("total_vat_withholding")]
        public decimal TotalVatWithholding { get; set; }

        [JsonProperty("total_discount")]
        public decimal TotalDiscount { get; set; }

        [JsonProperty("total_invoice_discount")]
        public decimal TotalInvoiceDiscount { get; set; }

        [JsonProperty("before_taxes_total")]
        public decimal BeforeTaxesTotal { get; set; }

        [JsonProperty("remaining")]
        public decimal Remaining { get; set; }

        [JsonProperty("remaining_in_trl")]
        public decimal RemainingInTrl { get; set; }

        [JsonProperty("payment_status")]
        public string PaymentStatus { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("issue_date")]
        public DateTime IssueDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("invoice_series")]
        public string InvoiceSeries { get; set; }

        [JsonProperty("invoice_id")]
        public int InvoiceId { get; set; }

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

        [JsonProperty("billing_postal_code")]
        public string BillingPostalCode { get; set; }

        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }

        [JsonProperty("billing_fax")]
        public string BillingFax { get; set; }

        [JsonProperty("tax_office")]
        public string TaxOffice { get; set; }

        [JsonProperty("tax_number")]
        public string TaxNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

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

        [JsonProperty("shipment_addres")]
        public string ShipmentAddress { get; set; }

        [JsonProperty("shipment_included")]
        public bool ShipmentIncluded { get; set; }

        [JsonProperty("cash_sale")]
        public bool CashSale { get; set; }

        [JsonProperty("payer_tax_numbers")]
        public List<string> PayerTaxNumbers { get; set; }
    }
}

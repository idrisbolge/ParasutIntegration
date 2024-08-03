namespace ParasutIntegration.Models.Product
{
    public class ParasutProductModel
    {
        public string SalesExciseDutyCode { get; set; }
        public int SalesInvoiceDetailsCount { get; set; }
        public int PurchaseInvoiceDetailsCount { get; set; }
        public decimal ListPriceInTrl { get; set; }
        public decimal BuyingPriceInTrl { get; set; }
        public int StockCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal VatRate { get; set; }
        public decimal SalesExciseDuty { get; set; }
        public string SalesExciseDutyType { get; set; }
        public decimal PurchaseExciseDuty { get; set; }
        public string PurchaseExciseDutyType { get; set; }
        public string Unit { get; set; }
        public decimal CommunicationsTaxRate { get; set; }
        public bool Archived { get; set; }
        public decimal ListPrice { get; set; }
        public string Currency { get; set; }
        public decimal BuyingPrice { get; set; }
        public string BuyingCurrency { get; set; }
        public bool InventoryTracking { get; set; }
        public int InitialStockCount { get; set; }
        public string Gtip { get; set; }
        public string Barcode { get; set; }


    }
}

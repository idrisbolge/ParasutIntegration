namespace ParasutIntegration.Models.Company
{
    public class CompanyContact
    {
        public string ContactType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ShortName { get; set; }
        public decimal Balance { get; set; }
        public decimal TrlBalance { get; set; }
        public decimal UsdBalance { get; set; }
        public decimal EurBalance { get; set; }
        public decimal GbpBalance { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public bool Archived { get; set; }
        public string AccountType { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}

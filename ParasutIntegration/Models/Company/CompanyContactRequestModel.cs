namespace ParasutIntegration.Models.Company
{
    public class CompanyContactRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ShortName { get; set; }
        public string ContactType { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsAbroad { get; set; }
        public bool Archived { get; set; }
        public string Iban { get; set; }
        public string AccountType { get; set; }
    }
}

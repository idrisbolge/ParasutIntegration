using ParasutIntegration.Models;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Models.SalesInvoice;
using ParasutIntegration.Models.ShipmentDocument;
using ParasutIntegration.Models.Stock;
using ParasutIntegration.Models.Warehouse;

namespace ParasutIntegration.Util
{
    public static class ParasutRequestFactory
    {
        public static ParasutRequestModel<T> CreateRequestModel<T>(
            string id,
            T attributes)
        {
            var typeName = typeof(T).Name;

            return new ParasutRequestModel<T>
            {
                Data = new ParasutRequestDataModel<T>
                {
                    Id = id,
                    Type = typeName switch
                    {
                        nameof(ParasutTransactionModel) => "transactions",
                        nameof(CompanyContactRequestModel) => "contacts",
                        nameof(AccountModel) => "accounts",
                        nameof(ParasutProductModel) => "products",
                        nameof(ParasutWarehouseModel) => "warehouses",
                        nameof(ParasutShipmentDocumentModel) => "shipment_documents",
                        nameof(ParasutStockUpdateModel) => "stock_updates",
                        nameof(ParasutOfferModel) => "sales_offers",
                        nameof(ParasutOfferPdfModel) => "trackable_jobs",
                        nameof(ParasutOfferStatusModel) => "sales_offers",
                        nameof(ParasutSalesInvoiceModel) => "sales_invoices",
                        _ => throw new ArgumentException("Unknown type")
                    },
                    Attributes = attributes
                }
            };
        }
    }

}

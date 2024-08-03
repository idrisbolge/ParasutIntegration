using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;

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
                        _ => throw new ArgumentException("Unknown type")
                    },
                    Attributes = attributes
                }
            };
        }
    }

}

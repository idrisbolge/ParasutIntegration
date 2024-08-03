namespace ParasutIntegration.Util
{
    public enum RouteEnum
    {
        CreateToken,
        RefreshToken,
        GetCompanyId,
        Company,
        Transaction,
        Account,
        Product,
        Warehouse,
        Default
    }


    public static class RouteEnumExtensions
    {

        public static string GetRouteString(this RouteEnum route)
        {
            string BaseUrl = "https://api.parasut.com";
            string CompanyId = "718416";
            return route switch
            {
                RouteEnum.CreateToken => $"{BaseUrl}/oauth/token",
                RouteEnum.RefreshToken => $"{BaseUrl}/oauth/token",
                RouteEnum.GetCompanyId => $"{BaseUrl}/v4/me",
                RouteEnum.Company => $"{BaseUrl}/v4/{CompanyId}/contacts",
                RouteEnum.Transaction => $"{BaseUrl}/v4/{CompanyId}/transactions",
                RouteEnum.Account => $"{BaseUrl}/v4/{CompanyId}/accounts",
                RouteEnum.Product => $"{BaseUrl}/v4/{CompanyId}/products",
                RouteEnum.Warehouse => $"{BaseUrl}/v4/{CompanyId}/warehouses",
                _ => throw new ArgumentException("Unknown route enum value")
            };
        }
    }
}

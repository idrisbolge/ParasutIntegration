namespace ParasutIntegration.Util
{
    public enum RouteEnum
    {
        CreateToken,
        RefreshToken,
        GetCompanyId,
        GetCompanyContact
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
                RouteEnum.GetCompanyContact => $"{BaseUrl}/v4/{CompanyId}/contacts",
                _ => throw new ArgumentException("Unknown route enum value")
            };
        }
    }
}

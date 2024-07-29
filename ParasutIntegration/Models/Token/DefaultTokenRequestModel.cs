namespace ParasutIntegration.Models.Token
{
    public class DefaultTokenRequestModel
    {
        public DefaultTokenRequestModel(string grantType)
        {
            grant_type = grantType;
        }

        public string grant_type { get; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }

}

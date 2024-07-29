namespace ParasutIntegration.Models.Token
{
    public class TokenRequestModel
    {
        public string grant_type { get; set; } = "password";
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string redirect_uri { get; set; } = "urn:ietf:wg:oauth:2.0:oob";
    }
}

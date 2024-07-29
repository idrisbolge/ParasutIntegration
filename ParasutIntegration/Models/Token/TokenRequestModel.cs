namespace ParasutIntegration.Models.Token
{
    public class TokenRequestModel : DefaultTokenRequestModel
    {
        public TokenRequestModel() : base("password") { }

        public string username { get; set; }
        public string password { get; set; }
        public string redirect_uri { get; set; } = "urn:ietf:wg:oauth:2.0:oob";
    }

}

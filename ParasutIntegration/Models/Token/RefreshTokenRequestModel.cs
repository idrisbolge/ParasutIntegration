namespace ParasutIntegration.Models.Token
{
    public class RefreshTokenRequestModel : DefaultTokenRequestModel
    {
        public RefreshTokenRequestModel() : base("refresh_token") { }

        public string refresh_token { get; set; }
    }

}

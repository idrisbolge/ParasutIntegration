namespace ParasutIntegration.Models.Token
{
    public class TokenModel : ParasutErrorResponse
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }
}

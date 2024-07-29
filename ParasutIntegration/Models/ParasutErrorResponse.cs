namespace ParasutIntegration.Models
{
    public class ParasutErrorResponse
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public bool success => string.IsNullOrEmpty(error);
    }
}

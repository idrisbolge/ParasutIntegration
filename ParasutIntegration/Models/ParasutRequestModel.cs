namespace ParasutIntegration.Models
{
    public class ParasutRequestModel<T>
    {
        public ParasutRequestDataModel<T> Data { get; set; }
    }

    public class ParasutRequestDataModel<T>
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public T Attributes { get; set; }
    }
}

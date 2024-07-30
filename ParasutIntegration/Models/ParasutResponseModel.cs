namespace ParasutIntegration.Models
{
    public class ParasutDataResponseModel<T> : IParasutResponseModel<T>
    {
        public List<ParasutResponseDetailModel<T>>? Data { get; set; }
        public List<ParasutErrorModel> Errors { get; set; }
    }

    public class ParasutResponseModel<T> : IParasutResponseModel<T>
    {
        public ParasutResponseDetailModel<T>? Data { get; set; }
        public List<ParasutErrorModel> Errors { get ; set ; }
    }


    public class ParasutResponseDetailModel<T>
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public T Attributes { get; set; }
    }

    public interface IParasutResponseModel<T>
    {
        List<ParasutErrorModel> Errors { get; set; }
    }

    public class ParasutErrorModel
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}

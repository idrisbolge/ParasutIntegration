using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Models;
using System.Text;

namespace ParasutIntegration.Features.General
{
    //public class GeneralRequest<TResponse> : IRequest<IParasutResponseModel<TResponse>>
    //{
    //    public string Url { get; }
    //    public object Parameters { get; }
    //    public bool IsTokenRequired { get; }
    //    public HttpMethod Method { get; }
    //    public bool IsList { get; }

    //    public GeneralRequest(string url, object parameters , HttpMethod method, bool isTokenRequired = false, bool isList = false)
    //    {
    //        Url = url;
    //        Parameters = parameters;
    //        Method = method;
    //        IsTokenRequired = isTokenRequired;
    //        IsList = isList;
    //    }
    //}


    //public class GeneralRequestHandler<TResponse> : IRequestHandler<GeneralRequest<TResponse>, IParasutResponseModel<TResponse>>
    //{
    //    private readonly IMediator _mediator;
    //    private readonly HttpClient _client;

    //    public GeneralRequestHandler(IMediator mediator, HttpClient client)
    //    {
    //        _mediator = mediator;
    //        _client = client;
    //    }

    //    public async Task<IParasutResponseModel<TResponse>> Handle(GeneralRequest<TResponse> request, CancellationToken cancellationToken)
    //    {
    //        //try
    //        //{
    //        //    if (request.IsTokenRequired)
    //        //    {
    //        //        var token = await _mediator.Send(new GetTokenQueries(), cancellationToken);
    //        //        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    //        //    }

    //        //    var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url);

    //        //    if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
    //        //    {
    //        //        string jsonString = JsonConvert.SerializeObject(request.Parameters);
    //        //        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
    //        //        httpRequestMessage.Content = content;
    //        //    }

    //        //    HttpResponseMessage response = await _client.SendAsync(httpRequestMessage, cancellationToken);
    //        //    response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response status is an error code

    //        //    string responseContent = await response.Content.ReadAsStringAsync();
    //        //    return request.IsList
    //        //        ? JsonConvert.DeserializeObject<ParasutDataResponseModel<TResponse>>(responseContent)
    //        //        : JsonConvert.DeserializeObject<ParasutResponseModel<TResponse>>(responseContent);
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    // Log the exception or handle it accordingly
    //        //    throw new ApplicationException("An error occurred while processing the request.", ex);
    //        //}
    //        return null;
    //    }
    //}


}

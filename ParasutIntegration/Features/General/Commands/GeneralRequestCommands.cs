using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Models;
using System.Text;

namespace ParasutIntegration.Features.General.Commands
{
    public class GeneralRequestCommands<TRequest, TResponse> : IRequest<IParasutResponseModel<TResponse>>
    {
        public string Url { get; }
        public TRequest Parameters { get; }
        public bool IsTokenRequired { get; }
        public HttpMethod Method { get; }

        public GeneralRequestCommands(string url, TRequest parameters, HttpMethod method, bool isTokenRequired = false)
        {
            Url = url;
            Parameters = parameters;
            Method = method;
            IsTokenRequired = isTokenRequired;
        }
    }

    public class GeneralRequestCommandsHandler<TRequest, TResponse> : IRequestHandler<GeneralRequestCommands<TRequest, TResponse>, IParasutResponseModel<TResponse>>
    {
        private readonly IMediator _mediator;

        public GeneralRequestCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<TResponse>> Handle(GeneralRequestCommands<TRequest, TResponse> request, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (request.IsTokenRequired)
                    {
                        var token = await _mediator.Send(new GetTokenQueries());
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
                    var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url);

                    if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
                    {
                        string jsonString = JsonConvert.SerializeObject(request.Parameters);
                        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        httpRequestMessage.Content = content;
                    }
                    HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ParasutResponseModel<TResponse>>(responseContent);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }


}

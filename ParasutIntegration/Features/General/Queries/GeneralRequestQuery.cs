using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Models;
using System.Text;

namespace ParasutIntegration.Features.General.Commands
{
    public class GeneralRequestQuery<TResponse> : IRequest<IParasutResponseModel<TResponse>>
    {
        public string Url { get; }
        public bool IsTokenRequired { get; }
        public HttpMethod Method { get; } = HttpMethod.Get;
        public bool IsList { get; }

        public GeneralRequestQuery(string url, bool isTokenRequired = false, bool isList = false)
        {
            Url = url;
            IsTokenRequired = isTokenRequired;
            IsList = isList;
        }
    }

    public class GeneralRequestQueryHandler<TResponse> : IRequestHandler<GeneralRequestQuery<TResponse>, IParasutResponseModel<TResponse>>
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _client;

        public GeneralRequestQueryHandler(IMediator mediator, HttpClient client)
        {
            _mediator = mediator;
            _client = client;
        }

        public async Task<IParasutResponseModel<TResponse>> Handle(GeneralRequestQuery<TResponse> request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IsTokenRequired)
                {
                    var token = await _mediator.Send(new GetTokenQueries(), cancellationToken);
                    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                var httpRequestMessage = new HttpRequestMessage(request.Method, request.Url);
                HttpResponseMessage response = await _client.SendAsync(httpRequestMessage, cancellationToken);

                response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response status is an error code

                string responseContent = await response.Content.ReadAsStringAsync();

                return request.IsList
                    ? JsonConvert.DeserializeObject<ParasutDataResponseModel<TResponse>>(responseContent)
                    : JsonConvert.DeserializeObject<ParasutResponseModel<TResponse>>(responseContent);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while processing the request.", ex);
            }
        }
    }
}

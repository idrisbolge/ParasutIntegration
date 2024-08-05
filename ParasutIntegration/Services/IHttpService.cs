using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Models;
using System.Text;

namespace ParasutIntegration.Services
{
    public interface IHttpService
    {
        Task<IParasutResponseModel<TResponse>> SendRequestAsync<TResponse>(string url, HttpMethod method, object parameters = null, bool isTokenRequired = false, bool isList = false);
    }
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        public HttpService(HttpClient client, IMediator mediator)
        {
            _client = client;
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<TResponse>> SendRequestAsync<TResponse>(string url, HttpMethod method, object parameters = null, bool isTokenRequired = false, bool isList = false)
        {
            if (isTokenRequired)
            {
                var token = await _mediator.Send(new GetTokenQueries());
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var httpRequestMessage = new HttpRequestMessage(method, url);

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                string jsonString = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                httpRequestMessage.Content = content;
            }

            HttpResponseMessage response = await _client.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            return isList
                ? JsonConvert.DeserializeObject<ParasutDataResponseModel<TResponse>>(responseContent)
                : JsonConvert.DeserializeObject<ParasutResponseModel<TResponse>>(responseContent);
        }
    }

}

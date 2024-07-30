using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Models.Token;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Auth.Commands
{
    public class GetTokenCommands : IRequest<TokenModel>
    {
        public DefaultTokenRequestModel parameters;

        public GetTokenCommands(DefaultTokenRequestModel parameters)
        {
            this.parameters = parameters;
        }

    }

    public class GetTokenCommandsHandler : IRequestHandler<GetTokenCommands, TokenModel>
    {
        public async Task<TokenModel> Handle(GetTokenCommands request, CancellationToken cancellationToken)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var parameters = DictionaryConverter.ToDictionary(request.parameters);
                    using (var content = new FormUrlEncodedContent(parameters))
                    {
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                        HttpResponseMessage response = await httpClient.PostAsync("https://api.parasut.com/oauth/token", content);
                        string responseString = await response.Content.ReadAsStringAsync();

                        TokenModel? tokenModel = JsonConvert.DeserializeObject<TokenModel>(responseString);

                        return tokenModel;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}

using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Models.Token;

namespace ParasutIntegration.Features.Auth.Commands
{
    public class GetTokenCommands : IRequest<TokenModel>
    {
        public TokenRequestModel parameters;

        public GetTokenCommands(TokenRequestModel parameters)
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
                    using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type",request.parameters.grant_type},
                    { "client_id",request.parameters.client_id},
                    { "client_secret",request.parameters.client_secret},
                    { "username",request.parameters.username},
                    { "password",request.parameters.password},
                    { "redirect_uri",request.parameters.redirect_uri}
                }))
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

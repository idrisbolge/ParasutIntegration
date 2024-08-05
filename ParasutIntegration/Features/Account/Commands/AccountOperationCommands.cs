using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Services;


namespace ParasutIntegration.Features.Account.Commands
{
    public class AccountOperationCommands : IRequest<IParasutResponseModel<AccountModel>>
    {
        public ParasutRequestModel<AccountModel> parameters;
        public HttpMethod method;

        public AccountOperationCommands(ParasutRequestModel<AccountModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class AccountOperationCommandsHandler : IRequestHandler<AccountOperationCommands, IParasutResponseModel<AccountModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public AccountOperationCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<AccountModel>> Handle(AccountOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Account.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response =
                    await httpService.SendRequestAsync<AccountModel>(
                        url: url,
                        parameters: request.parameters,
                        method: request.method,
                        isTokenRequired: true);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

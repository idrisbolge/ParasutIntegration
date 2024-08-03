using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Account;

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
        public AccountOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<AccountModel>> Handle(AccountOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Account.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<AccountModel>, AccountModel>(
                        url: url,
                        parameters: request.parameters,
                        method: request.method,
                        isTokenRequired: true));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

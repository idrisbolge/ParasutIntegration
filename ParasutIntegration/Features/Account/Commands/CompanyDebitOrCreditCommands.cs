using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Account.Commands
{
    public class AccountDebitOrCreditCommands : IRequest<IParasutResponseModel<ParasutTransactionModel>>
    {
        public ParasutRequestModel<ParasutTransactionModel> parameters;
        public HttpMethod method;
        public char DebitOrCredit;
        public AccountDebitOrCreditCommands(ParasutRequestModel<ParasutTransactionModel> parameters, HttpMethod method, char debitOrCredit)
        {
            this.parameters = parameters;
            this.method = method;
            DebitOrCredit = debitOrCredit;
        }
    }

    public class AccountDebitOrCreditCommandsHandler : IRequestHandler<AccountDebitOrCreditCommands, IParasutResponseModel<ParasutTransactionModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;

        public AccountDebitOrCreditCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(AccountDebitOrCreditCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var debitOrCreditPath = $"{(request.DebitOrCredit == 'D' ? "debit" : "credit")}_transactions";
                var url = RouteEnum.Account.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}/{debitOrCreditPath}");

                var response = 
                    await httpService.SendRequestAsync<ParasutTransactionModel>(
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

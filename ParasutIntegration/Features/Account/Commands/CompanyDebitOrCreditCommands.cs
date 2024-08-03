using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
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
        public AccountDebitOrCreditCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(AccountDebitOrCreditCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var debitOrCreditPath = $"{(request.DebitOrCredit == 'D' ? "debit" : "credit")}_transactions";
                var url = RouteEnum.Account.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}/{debitOrCreditPath}");

                var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<ParasutTransactionModel>, ParasutTransactionModel>(
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

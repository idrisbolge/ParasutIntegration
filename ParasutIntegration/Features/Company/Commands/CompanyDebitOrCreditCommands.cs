using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Company.Commands
{
    public class CompanyDebitOrCreditCommands : IRequest<IParasutResponseModel<ParasutTransactionModel>>
    {
        public ParasutRequestModel<ParasutTransactionModel> parameters;
        public HttpMethod method;
        public char DebitOrCredit;
        public CompanyDebitOrCreditCommands(ParasutRequestModel<ParasutTransactionModel> parameters, HttpMethod method, char debitOrCredit)
        {
            this.parameters = parameters;
            this.method = method;
            DebitOrCredit = debitOrCredit;
        }
    }

    public class CompanyDebitOrCreditCommandsHandler : IRequestHandler<CompanyDebitOrCreditCommands, IParasutResponseModel<ParasutTransactionModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public CompanyDebitOrCreditCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }

        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(CompanyDebitOrCreditCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var debitOrCreditPath = $"contact_{(request.DebitOrCredit == 'D' ? "debit" : "credit")}_transactions";
                var url = RouteEnum.Company.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}/{debitOrCreditPath}");

                var response = await httpService.SendRequestAsync<ParasutTransactionModel>(
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

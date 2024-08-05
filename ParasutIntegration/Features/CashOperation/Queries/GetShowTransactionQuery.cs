using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.CashOperation.Queries
{
    public class GetShowTransactionQuery : IRequest<IParasutResponseModel<ParasutTransactionModel>>
    {
        public int Id { get; set; }

        public GetShowTransactionQuery(int id)
        {
            Id = id;
        }
    }

    public class GetShowTransactionQueryHandler : IRequestHandler<GetShowTransactionQuery, IParasutResponseModel<ParasutTransactionModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public GetShowTransactionQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
       

        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(GetShowTransactionQuery request, CancellationToken cancellationToken)
        {

            return await httpService.SendRequestAsync<ParasutTransactionModel>(url: RouteEnum.Transaction.GetRouteString() + $"/{request.Id}", isTokenRequired: true, parameters: null, method: HttpMethod.Get);
        }
    }

}

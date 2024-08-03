using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
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

        public GetShowTransactionQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(GetShowTransactionQuery request, CancellationToken cancellationToken)
        {

            return await _mediator.Send(new GeneralRequestQuery<ParasutTransactionModel>(url: RouteEnum.Transaction.GetRouteString() + $"/{request.Id}", isTokenRequired: true));
        }
    }

}

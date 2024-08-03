using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Features.Product.Queries;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Account.Queries
{
    public class GetAccountsQuery : IRequest<IParasutResponseModel<AccountModel>>
    {
        public int id;

        public GetAccountsQuery(int id = 0)
        {
            this.id = id;
        }
    }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IParasutResponseModel<AccountModel>>
    {
        private readonly IMediator _mediator;

        public GetAccountsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<AccountModel>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Product.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await _mediator.Send(new GeneralRequestQuery<AccountModel>(route, true, request.id == 0));
        }
    }

}

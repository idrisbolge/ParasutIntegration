using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Services;
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
        private readonly IHttpService httpService;
        public GetAccountsQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }

        public async Task<IParasutResponseModel<AccountModel>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Product.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await httpService.SendRequestAsync<AccountModel>(url: route, isTokenRequired: true, isList: request.id == 0, parameters: null, method: HttpMethod.Get);
        }
    }

}

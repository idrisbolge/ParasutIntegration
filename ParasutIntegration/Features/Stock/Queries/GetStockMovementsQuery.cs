using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Services;
using ParasutIntegration.Models.Stock;

namespace ParasutIntegration.Features.Stock.Queries
{
    public class GetStockMovementsQuery : IRequest<IParasutResponseModel<ParasutStockMovementModel>>
    {

    }
    public class GetStockMovementsQueryHandler : IRequestHandler<GetStockMovementsQuery, IParasutResponseModel<ParasutStockMovementModel>>
    {
        private readonly IHttpService httpService;
        public GetStockMovementsQueryHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutStockMovementModel>> Handle(GetStockMovementsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.StockMovement.GetRouteString();
            return await httpService.SendRequestAsync<ParasutStockMovementModel>
                (url: route, isTokenRequired: true, isList: true, method: HttpMethod.Get, parameters: null);
        }
    }

}

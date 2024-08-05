using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Services;
using ParasutIntegration.Models.Stock;


namespace ParasutIntegration.Features.Stock.Queries
{
    public class GetInventoryLevelQuery : IRequest<IParasutResponseModel<ParasutInventoryLevelModel>>
    {
        public int productId;

        public GetInventoryLevelQuery(int productId)
        {
            this.productId = productId;
        }
    }
    public class GetInventoryLevelQueryHandler : IRequestHandler<GetInventoryLevelQuery, IParasutResponseModel<ParasutInventoryLevelModel>>
    {
        private readonly IHttpService httpService;
        public GetInventoryLevelQueryHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutInventoryLevelModel>> Handle(GetInventoryLevelQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.InventoryLevel.GetRouteString().Replace("productId", request.productId.ToString());
            return await httpService.SendRequestAsync<ParasutInventoryLevelModel>
                (url: route, isTokenRequired: true, isList: true, method: HttpMethod.Get, parameters: null);
        }
    }

}

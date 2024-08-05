using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Features.General;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Warehouse.Queries
{
    public class GetWarehousesQuery : IRequest<IParasutResponseModel<ParasutWarehouseModel>>
    {
        public int Id { get; }

        public GetWarehousesQuery(int id)
        {
            Id = id;
        }
    }
    public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, IParasutResponseModel<ParasutWarehouseModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public GetWarehousesQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        

        public async Task<IParasutResponseModel<ParasutWarehouseModel>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Warehouse.GetRouteString() + (request.Id == 0 ? "" : $"/{request.Id}");
            return await httpService.SendRequestAsync< ParasutWarehouseModel>
                (url: route, isTokenRequired: true, isList: request.Id == 0, method: HttpMethod.Get, parameters: null);
        }
    }

}

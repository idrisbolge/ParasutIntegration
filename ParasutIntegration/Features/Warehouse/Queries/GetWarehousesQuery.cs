using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Models.Product;

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

        public GetWarehousesQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<ParasutWarehouseModel>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Product.GetRouteString() + (request.Id == 0 ? "" : $"/{request.Id}");
            return await _mediator.Send(new GeneralRequestQuery<ParasutWarehouseModel>(route, true, request.Id == 0));
        }
    }

}

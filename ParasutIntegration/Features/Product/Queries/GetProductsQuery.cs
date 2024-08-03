using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models.Product;

namespace ParasutIntegration.Features.Product.Queries
{
    public class GetProductsQuery : IRequest<IParasutResponseModel<ParasutProductModel>>
    {
        public int id;

        public GetProductsQuery(int id = 0)
        {
            this.id = id;
        }
    }
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IParasutResponseModel<ParasutProductModel>>
    {
        private readonly IMediator _mediator;

        public GetProductsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<ParasutProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Product.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await _mediator.Send(new GeneralRequestQuery<ParasutProductModel>(route, true, request.id == 0));
        }
    }
}

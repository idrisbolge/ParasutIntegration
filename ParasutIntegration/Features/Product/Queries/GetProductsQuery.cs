using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Features.General;
using ParasutIntegration.Services;

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
        private readonly IHttpService httpService;
        public GetProductsQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Product.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await httpService.SendRequestAsync<ParasutProductModel>(url: route, isTokenRequired: true, isList: request.id == 0, parameters: null, method: HttpMethod.Get);
        }
    }
}

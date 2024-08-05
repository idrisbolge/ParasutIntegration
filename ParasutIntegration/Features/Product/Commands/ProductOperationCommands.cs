using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Features.General;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Product.Commands
{
    public class ProductOperationCommands : IRequest<IParasutResponseModel<ParasutProductModel>>
    {
        public ParasutRequestModel<ParasutProductModel> parameters;
        public HttpMethod method;

        public ProductOperationCommands(ParasutRequestModel<ParasutProductModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class ProductOperationCommandsHandler : IRequestHandler<ProductOperationCommands, IParasutResponseModel<ParasutProductModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public ProductOperationCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }

        public async Task<IParasutResponseModel<ParasutProductModel>> Handle(ProductOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Product.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync<ParasutProductModel>(
                        url: url,
                        parameters: request.parameters,
                        method: request.method,
                        isTokenRequired: true);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

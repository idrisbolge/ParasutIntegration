using MediatR;
using ParasutIntegration.Features.General.Commands;

using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Product;

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
        public ProductOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<ParasutProductModel>> Handle(ProductOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Product.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<ParasutProductModel>, ParasutProductModel>(
                        url: url,
                        parameters: request.parameters,
                        method: request.method,
                        isTokenRequired: true));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

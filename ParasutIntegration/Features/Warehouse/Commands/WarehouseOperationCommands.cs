using MediatR;
using ParasutIntegration.Features.General.Commands;

using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Models.Warehouse;

namespace ParasutIntegration.Features.Warehouse.Commands
{
    public class WarehouseOperationCommands : IRequest<IParasutResponseModel<ParasutWarehouseModel>>
    {
        public ParasutRequestModel<ParasutWarehouseModel> parameters;
        public HttpMethod method;

        public WarehouseOperationCommands(ParasutRequestModel<ParasutWarehouseModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class WarehouseOperationCommandsHandler : IRequestHandler<WarehouseOperationCommands, IParasutResponseModel<ParasutWarehouseModel>>
    {
        private readonly IMediator _mediator;
        public WarehouseOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<ParasutWarehouseModel>> Handle(WarehouseOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Warehouse.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<ParasutWarehouseModel>, ParasutWarehouseModel>(
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

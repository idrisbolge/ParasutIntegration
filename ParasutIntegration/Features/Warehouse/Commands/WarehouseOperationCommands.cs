using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Features.General;
using ParasutIntegration.Services;

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
        private readonly IHttpService httpService;
        public WarehouseOperationCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        public WarehouseOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<ParasutWarehouseModel>> Handle(WarehouseOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Warehouse.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync< ParasutWarehouseModel>(
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

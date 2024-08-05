using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.ShipmentDocument;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.ShipmentDocument.Commands
{
    public class ShipmentDocumentOperationCommands : IRequest<IParasutResponseModel<ParasutShipmentDocumentModel>>
    {
        public ParasutRequestModel<ParasutShipmentDocumentModel> parameters;
        public HttpMethod method;

        public ShipmentDocumentOperationCommands(ParasutRequestModel<ParasutShipmentDocumentModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class ShipmentDocumentOperationCommandsHandler : IRequestHandler<ShipmentDocumentOperationCommands, IParasutResponseModel<ParasutShipmentDocumentModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public ShipmentDocumentOperationCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        public ShipmentDocumentOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<ParasutShipmentDocumentModel>> Handle(ShipmentDocumentOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.ShipmentDocument.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync< ParasutShipmentDocumentModel>(
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

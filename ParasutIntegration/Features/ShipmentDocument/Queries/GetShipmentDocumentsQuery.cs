using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Features.General;
using ParasutIntegration.Services;
using ParasutIntegration.Models.ShipmentDocument;

namespace ParasutIntegration.Features.ShipmentDocument.Queries
{
    public class GetShipmentDocumentsQuery : IRequest<IParasutResponseModel<ParasutShipmentDocumentModel>>
    {
        public int Id { get; }

        public GetShipmentDocumentsQuery(int id)
        {
            Id = id;
        }
    }
    public class GetShipmentDocumentsQueryHandler : IRequestHandler<GetShipmentDocumentsQuery, IParasutResponseModel<ParasutShipmentDocumentModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public GetShipmentDocumentsQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        

        public async Task<IParasutResponseModel<ParasutShipmentDocumentModel>> Handle(GetShipmentDocumentsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.ShipmentDocument.GetRouteString() + (request.Id == 0 ? "" : $"/{request.Id}");
            return await httpService.SendRequestAsync<ParasutShipmentDocumentModel>
                (url: route, isTokenRequired: true, isList: request.Id == 0, method: HttpMethod.Get, parameters: null);
        }
    }

}

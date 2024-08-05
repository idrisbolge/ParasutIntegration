using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class OfferOperationCommands : IRequest<IParasutResponseModel<ParasutOfferModel>>
    {
        public ParasutRequestModel<ParasutOfferModel> parameters;
        public HttpMethod method;

        public OfferOperationCommands(ParasutRequestModel<ParasutOfferModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class OfferOperationCommandsHandler : IRequestHandler<OfferOperationCommands, IParasutResponseModel<ParasutOfferModel>>
    {
        private readonly IHttpService httpService;
        public OfferOperationCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutOfferModel>> Handle(OfferOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Offer.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync< ParasutOfferModel>(
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

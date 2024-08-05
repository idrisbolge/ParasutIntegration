using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class OfferMailCommands : IRequest<IParasutResponseModel<ParasutOfferMailResponseModel>>
    {
        public ParasutRequestModel<ParasutOfferMailRequestModel> parameters;
        public HttpMethod method;

        public OfferMailCommands(ParasutRequestModel<ParasutOfferMailRequestModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class OfferMailCommandsHandler : IRequestHandler<OfferMailCommands, IParasutResponseModel<ParasutOfferMailResponseModel>>
    {
        private readonly IHttpService httpService;
        public OfferMailCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutOfferMailResponseModel>> Handle(OfferMailCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Offer.GetRouteString();

                var response = await httpService.SendRequestAsync<ParasutOfferMailResponseModel>(
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

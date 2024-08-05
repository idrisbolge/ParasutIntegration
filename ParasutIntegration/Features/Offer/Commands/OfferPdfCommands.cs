using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class OfferPdfCommands : IRequest<IParasutResponseModel<ParasutOfferPdfModel>>
    {
        public ParasutRequestModel<ParasutOfferPdfModel> parameters;
        public HttpMethod method;

        public OfferPdfCommands(ParasutRequestModel<ParasutOfferPdfModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class OfferPdfCommandsHandler : IRequestHandler<OfferPdfCommands, IParasutResponseModel<ParasutOfferPdfModel>>
    {
        private readonly IHttpService httpService;
        public OfferPdfCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutOfferPdfModel>> Handle(OfferPdfCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Offer.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}") + "/pdf";

                var response = await httpService.SendRequestAsync<ParasutOfferPdfModel>(
                        url: url,
                        parameters: null,
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

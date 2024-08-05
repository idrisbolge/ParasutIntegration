using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class OfferArchiveCommands : IRequest<IParasutResponseModel<ParasutOfferModel>>
    {
        public bool archive;
        public int offerId;
        public OfferArchiveCommands(bool archive, int offerId)
        {
            this.archive = archive;
            this.offerId = offerId;
        }
    }

    public class OfferArchiveCommandsHandler : IRequestHandler<OfferArchiveCommands, IParasutResponseModel<ParasutOfferModel>>
    {
        private readonly IHttpService httpService;
        public OfferArchiveCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutOfferModel>> Handle(OfferArchiveCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Offer.GetRouteString() + $"/{request.offerId}/{(request.archive ? "archive" : "unarchive")}";

                var response = await httpService.SendRequestAsync<ParasutOfferModel>(
                        url: url,
                        parameters: null,
                        method: HttpMethod.Patch,
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

using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;
using ParasutIntegration.Enums;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class ChangeOfferStatusCommands : IRequest<IParasutResponseModel<ParasutOfferModel>>
    {
        public ParasutRequestModel<ParasutOfferStatusModel> parameters { get; set; }
        public int offerId { get; set; }

        public ChangeOfferStatusCommands(ParasutRequestModel<ParasutOfferStatusModel> parameters, int offerId)
        {
            this.parameters = parameters;
            this.offerId = offerId;
        }
    }

    public class ChangeOfferStatusCommandsHandler : IRequestHandler<ChangeOfferStatusCommands, IParasutResponseModel<ParasutOfferModel>>
    {
        private readonly IHttpService httpService;
        public ChangeOfferStatusCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutOfferModel>> Handle(ChangeOfferStatusCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Offer.GetRouteString() + $"/{request.offerId}/update_status";

                var response = await httpService.SendRequestAsync<ParasutOfferModel>(
                        url: url,
                        parameters: request.parameters,
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

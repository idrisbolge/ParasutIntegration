using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Queries
{
    public class GetOfferDetailsQuery : IRequest<IParasutResponseModel<ParasutOfferDetailModel>>
    {
        public int OfferId { get; }

        public GetOfferDetailsQuery(int offerId)
        {
           OfferId = offerId;
        }
    }
    public class GetOfferDetailsQueryHandler : IRequestHandler<GetOfferDetailsQuery, IParasutResponseModel<ParasutOfferDetailModel>>
    {
        private readonly IHttpService httpService;
        public GetOfferDetailsQueryHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutOfferDetailModel>> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Offer.GetRouteString() + $"/{request.OfferId}/details";
            return await httpService.SendRequestAsync<ParasutOfferDetailModel>
                (url: route, isTokenRequired: true, isList: request.OfferId == 0, method: HttpMethod.Get, parameters: null);
        }
    }

}

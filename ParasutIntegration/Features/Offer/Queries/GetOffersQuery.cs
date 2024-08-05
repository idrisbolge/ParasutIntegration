using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.Offer.Queries
{
    public class GetOffersQuery : IRequest<IParasutResponseModel<ParasutOfferModel>>
    {
        public int Id { get; }

        public GetOffersQuery(int id)
        {
            Id = id;
        }
    }
    public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery, IParasutResponseModel<ParasutOfferModel>>
    {
        private readonly IHttpService httpService;
        public GetOffersQueryHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutOfferModel>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Offer.GetRouteString() + (request.Id == 0 ? "" : $"/{request.Id}");
            return await httpService.SendRequestAsync<ParasutOfferModel>
                (url: route, isTokenRequired: true, isList: request.Id == 0, method: HttpMethod.Get, parameters: null);
        }
    }

}

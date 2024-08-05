using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Company.Queries
{
    public class GetCompanyContactQuery : IRequest<IParasutResponseModel<CompanyContact>>
    {
        public int id;

        public GetCompanyContactQuery(int id = 0)
        {
            this.id = id;
        }
    }


    public class GetCompanyContactQueryHandler : IRequestHandler<GetCompanyContactQuery, IParasutResponseModel<CompanyContact>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public GetCompanyContactQueryHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }


        async Task<IParasutResponseModel<CompanyContact>> IRequestHandler<GetCompanyContactQuery, IParasutResponseModel<CompanyContact>>.Handle(GetCompanyContactQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Company.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await httpService.SendRequestAsync<CompanyContact>(url: route, isTokenRequired: true, isList: request.id == 0, parameters: null, method: HttpMethod.Get);
        }
    }
}

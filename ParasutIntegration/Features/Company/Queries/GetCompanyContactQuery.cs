using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
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
        private static readonly HttpClient client = new HttpClient();
        public GetCompanyContactQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        async Task<IParasutResponseModel<CompanyContact>> IRequestHandler<GetCompanyContactQuery, IParasutResponseModel<CompanyContact>>.Handle(GetCompanyContactQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.Company.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            return await _mediator.Send(new GeneralRequestQuery<CompanyContact>(route, true, (request.id == 0)));
        }
    }
}

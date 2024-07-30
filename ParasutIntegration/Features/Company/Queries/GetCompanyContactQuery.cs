using MediatR;
using Newtonsoft.Json;
using ParasutIntegration.Features.Auth.Queries;
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
            var token = await _mediator.Send(new GetTokenQueries());

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var route = RouteEnum.GetCompanyContact.GetRouteString() + (request.id == 0 ? "" : $"/{request.id}");
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            if (request.id == 0)
                return JsonConvert.DeserializeObject<ParasutDataResponseModel<CompanyContact>>(json);
            else
                return JsonConvert.DeserializeObject<ParasutResponseModel<CompanyContact>>(json);

        }
    }
}

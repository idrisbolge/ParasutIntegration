using MediatR;
using Newtonsoft.Json.Linq;
using ParasutIntegration.Features.Auth.Queries;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Company.Queries
{
    public class GetCompanyIdQuery : IRequest<string>
    {
    }


    public class GetCompanyIdQueryHandler : IRequestHandler<GetCompanyIdQuery, string>
    {
        private IMediator _mediator;

        public GetCompanyIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(GetCompanyIdQuery request, CancellationToken cancellationToken)
        {

            using (var client = new HttpClient())
            {
                var token = await _mediator.Send(new GetTokenQueries());
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var result = await client.GetAsync(RouteEnum.GetCompanyId.GetRouteString());
                var response = await result.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(response);
                var CompanyId = jsonObject?["included"]?[0]?["relationships"]?["company"]?["data"]?["id"]?.ToString();
                return CompanyId;
            }
        }
    }




}

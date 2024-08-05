using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;

namespace ParasutIntegration.Features.Company.Commands
{
    public class CompanyOperationCommands : IRequest<IParasutResponseModel<CompanyContact>>
    {
        public ParasutRequestModel<CompanyContactRequestModel> parameters;
        public HttpMethod method;

        public CompanyOperationCommands(ParasutRequestModel<CompanyContactRequestModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class CompanyOperationCommandsHandler : IRequestHandler<CompanyOperationCommands, IParasutResponseModel<CompanyContact>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public CompanyOperationCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<CompanyContact>> Handle(CompanyOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Company.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync<CompanyContact>(
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

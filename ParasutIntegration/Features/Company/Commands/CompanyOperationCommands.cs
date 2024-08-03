using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
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
        public CompanyOperationCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IParasutResponseModel<CompanyContact>> Handle(CompanyOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.Company.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<CompanyContactRequestModel>, CompanyContact>(
                        url: url,
                        parameters: request.parameters,
                        method: request.method,
                        isTokenRequired: true));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

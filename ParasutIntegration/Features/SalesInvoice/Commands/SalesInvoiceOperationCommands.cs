using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.SalesInvoice;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.SalesInvoice.Commands
{
    public class SalesInvoiceOperationCommands : IRequest<IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        public ParasutRequestModel<ParasutSalesInvoiceModel> parameters;
        public HttpMethod method;

        public SalesInvoiceOperationCommands(ParasutRequestModel<ParasutSalesInvoiceModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class SalesInvoiceOperationCommandsHandler : IRequestHandler<SalesInvoiceOperationCommands, IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        private readonly IHttpService httpService;
        public SalesInvoiceOperationCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutSalesInvoiceModel>> Handle(SalesInvoiceOperationCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.SalesInvoice.GetRouteString() + (request.method == HttpMethod.Post ? "" : $"/{request.parameters.Data.Id}");

                var response = await httpService.SendRequestAsync< ParasutSalesInvoiceModel>(
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

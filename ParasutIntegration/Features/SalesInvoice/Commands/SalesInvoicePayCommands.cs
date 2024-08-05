using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;
using ParasutIntegration.Models.SalesInvoice;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class SalesInvoicePayCommands : IRequest<IParasutResponseModel<ParasutSalesInvoicePayResponseModel>>
    {
        public ParasutRequestModel<ParasutSalesInvoicePayRequestModel> parameters;
        public HttpMethod method;

        public SalesInvoicePayCommands(ParasutRequestModel<ParasutSalesInvoicePayRequestModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class SalesInvoicePayCommandsHandler : IRequestHandler<SalesInvoicePayCommands, IParasutResponseModel<ParasutSalesInvoicePayResponseModel>>
    {
        private readonly IHttpService httpService;
        public SalesInvoicePayCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutSalesInvoicePayResponseModel>> Handle(SalesInvoicePayCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.SalesInvoice.GetRouteString() + $"/{request.parameters.Data.Id}/payments";

                var response = await httpService.SendRequestAsync<ParasutSalesInvoicePayResponseModel>(
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

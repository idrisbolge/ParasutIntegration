using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.Offer;
using ParasutIntegration.Services;
using ParasutIntegration.Models.SalesInvoice;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class SalesInvoiceCancelCommands : IRequest<IParasutResponseModel<ParasutSalesInvoiceModel>>
    {

        public int invoiceId { get; set; }
        public SalesInvoiceCancelCommands(int invoiceId)
        {
            this.invoiceId = invoiceId;
        }
    }

    public class SalesInvoiceCancelCommandsHandler : IRequestHandler<SalesInvoiceCancelCommands, IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        private readonly IHttpService httpService;
        public SalesInvoiceCancelCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutSalesInvoiceModel>> Handle(SalesInvoiceCancelCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.SalesInvoice.GetRouteString() + $"{request.invoiceId}/cancel";

                var response = await httpService.SendRequestAsync<ParasutSalesInvoiceModel>(
                        url: url,
                        parameters: null,
                        method: HttpMethod.Delete,
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

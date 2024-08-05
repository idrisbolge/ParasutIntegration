using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Services;
using ParasutIntegration.Models.SalesInvoice;

namespace ParasutIntegration.Features.Offer.Commands
{
    public class SalesInvoiceRecoverCommands : IRequest<IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        public int invoiceId { get; set; }

        public SalesInvoiceRecoverCommands(int invoiceId)
        {
            this.invoiceId = invoiceId;
        }
    }

    public class SalesInvoiceRecoverCommandsHandler : IRequestHandler<SalesInvoiceRecoverCommands, IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        private readonly IHttpService httpService;
        public SalesInvoiceRecoverCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutSalesInvoiceModel>> Handle(SalesInvoiceRecoverCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.SalesInvoice.GetRouteString() + $"/{request.invoiceId}/recover";

                var response = await httpService.SendRequestAsync<ParasutSalesInvoiceModel>(
                        url: url,
                        parameters: null,
                        method: HttpMethod.Patch,
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

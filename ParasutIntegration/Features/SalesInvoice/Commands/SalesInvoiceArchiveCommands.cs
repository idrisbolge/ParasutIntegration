using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.SalesInvoice;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.SalesInvoice.Commands
{
    public class SalesInvoiceArchiveCommands : IRequest<IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        public bool archive;
        public int SalesInvoiceId;
        public SalesInvoiceArchiveCommands(bool archive, int SalesInvoiceId)
        {
            this.archive = archive;
            this.SalesInvoiceId = SalesInvoiceId;
        }
    }

    public class SalesInvoiceArchiveCommandsHandler : IRequestHandler<SalesInvoiceArchiveCommands, IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        private readonly IHttpService httpService;
        public SalesInvoiceArchiveCommandsHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task<IParasutResponseModel<ParasutSalesInvoiceModel>> Handle(SalesInvoiceArchiveCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.SalesInvoice.GetRouteString() + $"/{request.SalesInvoiceId}/{(request.archive ? "archive" : "unarchive")}";

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

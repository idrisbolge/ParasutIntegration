using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Models.SalesInvoice;
using ParasutIntegration.Services;

namespace ParasutIntegration.Features.SalesInvoice.Queries
{
    public class GetSalesInvoicesQuery : IRequest<IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        public int Id { get; }

        public GetSalesInvoicesQuery(int id)
        {
            Id = id;
        }
    }
    public class GetSalesInvoicesQueryHandler : IRequestHandler<GetSalesInvoicesQuery, IParasutResponseModel<ParasutSalesInvoiceModel>>
    {
        private readonly IHttpService httpService;
        public GetSalesInvoicesQueryHandler(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutSalesInvoiceModel>> Handle(GetSalesInvoicesQuery request, CancellationToken cancellationToken)
        {
            var route = RouteEnum.SalesInvoice.GetRouteString() + (request.Id == 0 ? "" : $"/{request.Id}");
            return await httpService.SendRequestAsync<ParasutSalesInvoiceModel>
                (url: route, isTokenRequired: true, isList: request.Id == 0, method: HttpMethod.Get, parameters: null);
        }
    }

}

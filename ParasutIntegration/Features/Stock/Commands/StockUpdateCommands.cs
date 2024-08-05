using MediatR;
using ParasutIntegration.Models;
using ParasutIntegration.Util;
using ParasutIntegration.Services;
using ParasutIntegration.Models.Stock;

namespace ParasutIntegration.Features.Stock.Commands
{
    public class StockUpdateCommands : IRequest<IParasutResponseModel<ParasutStockUpdateModel>>
    {
        public ParasutRequestModel<ParasutStockUpdateModel> parameters;
        public HttpMethod method;

        public StockUpdateCommands(ParasutRequestModel<ParasutStockUpdateModel> parameters, HttpMethod method)
        {
            this.parameters = parameters;
            this.method = method;
        }
    }

    public class StockUpdateCommandsHandler : IRequestHandler<StockUpdateCommands, IParasutResponseModel<ParasutStockUpdateModel>>
    {
        private readonly IHttpService httpService;
        public StockUpdateCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IParasutResponseModel<ParasutStockUpdateModel>> Handle(StockUpdateCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var url = RouteEnum.StockUpdate.GetRouteString();

                var response = await httpService.SendRequestAsync<ParasutStockUpdateModel>(
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

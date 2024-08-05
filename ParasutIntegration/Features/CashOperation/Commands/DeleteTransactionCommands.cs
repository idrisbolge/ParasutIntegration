using MediatR;
using ParasutIntegration.Features.General;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Services;
using ParasutIntegration.Util;
using System;

namespace ParasutIntegration.Features.CashOperation.Commands
{
    public class DeleteTransactionCommands : IRequest<IParasutResponseModel<ParasutTransactionModel>>
    {
        public int Id { get; set; }

        public DeleteTransactionCommands(int id)
        {
            Id = id;
        }
    }

    public class DeleteTransactionCommandsHandler : IRequestHandler<DeleteTransactionCommands, IParasutResponseModel<ParasutTransactionModel>>
    {
        private readonly IMediator _mediator;
        private readonly IHttpService httpService;
        public DeleteTransactionCommandsHandler(IMediator mediator, IHttpService httpService)
        {
            _mediator = mediator;
            this.httpService = httpService;
        }


        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(DeleteTransactionCommands request, CancellationToken cancellationToken)
        {
            var response = await httpService.SendRequestAsync<ParasutTransactionModel>(
                        url: RouteEnum.Transaction.GetRouteString() + $"/{request.Id}",
                        parameters: null,
                        method: HttpMethod.Delete,
                        isTokenRequired: true);


            return response;
        }
    }
}

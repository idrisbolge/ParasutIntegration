using MediatR;
using ParasutIntegration.Features.General.Commands;
using ParasutIntegration.Models;
using ParasutIntegration.Models.Company;
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

        public DeleteTransactionCommandsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IParasutResponseModel<ParasutTransactionModel>> Handle(DeleteTransactionCommands request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(
                    new GeneralRequestCommands<ParasutRequestModel<ParasutTransactionModel>, ParasutTransactionModel>(
                        url: RouteEnum.Transaction.GetRouteString() + $"/{request.Id}",
                        parameters: null,
                        method: HttpMethod.Delete,
                        isTokenRequired: true));


            return response;
        }
    }
}

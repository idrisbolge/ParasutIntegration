using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.CashOperation.Commands;
using ParasutIntegration.Features.CashOperation.Queries;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/CashOperation")]
    [ApiController]
    public class CashOperationController : Controller
    {
        private readonly IMediator _mediator;

        public CashOperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetShowTransactionQuery(id));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteTransactionCommands(id));
            return Ok(response);
        }
    }
}

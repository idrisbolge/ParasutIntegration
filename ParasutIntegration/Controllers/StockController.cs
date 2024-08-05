using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Stock.Commands;
using ParasutIntegration.Features.Stock.Queries;
using ParasutIntegration.Models.Stock;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/Stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("StockMovements")]
        public async Task<IActionResult> GetStockMovements()
        {
            var stockMovements = await _mediator.Send(new GetStockMovementsQuery());
            return Ok(stockMovements);
        }

        [HttpGet("InventoryLevel")]
        public async Task<IActionResult> GetInventoryLevels(int productId)
        {
            var inventoryLevels = await _mediator.Send(new GetInventoryLevelQuery(productId));
            return Ok(inventoryLevels);
        }



        [HttpPost]
        public async Task<IActionResult> Post(ParasutStockUpdateModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new StockUpdateCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

    }
}

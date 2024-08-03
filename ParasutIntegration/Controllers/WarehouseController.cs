using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Warehouse.Commands;
using ParasutIntegration.Features.Warehouse.Queries;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/Warehouse")]
    [ApiController]

    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllWarehouse")]
        public async Task<IActionResult> GetAllWarehouseContact()
        {
            var WarehouseContact = await _mediator.Send(new GetWarehousesQuery(0));
            return Ok(WarehouseContact);
        }

        [HttpGet("GetWarehouseById")]
        public async Task<IActionResult> GetWarehouseContactById(int id)
        {
            var WarehouseContact = await _mediator.Send(new GetWarehousesQuery(id));
            return Ok(WarehouseContact);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(ParasutWarehouseModel model)
        //{
        //    var parameters = ParasutRequestFactory.CreateRequestModel("", model);
        //    var response = await _mediator.Send(new WarehouseOperationCommands(parameters, HttpMethod.Post));
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(ParasutWarehouseModel model, string id)
        //{
        //    var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
        //    var response = await _mediator.Send(new WarehouseOperationCommands(parameters, HttpMethod.Put));
        //    return Ok(response);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var parameters = ParasutRequestFactory.CreateRequestModel(id, new ParasutWarehouseModel());
        //    var response = await _mediator.Send(new WarehouseOperationCommands(parameters, HttpMethod.Delete));
        //    return Ok(response);
        //}
    }
}

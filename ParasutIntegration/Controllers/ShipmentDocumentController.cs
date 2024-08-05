using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.ShipmentDocument.Commands;
using ParasutIntegration.Features.ShipmentDocument.Queries;
using ParasutIntegration.Models.ShipmentDocument;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/ShipmentDocument")]
    [ApiController]

    public class ShipmentDocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllShipmentDocument")]
        public async Task<IActionResult> GetAllShipmentDocumentContact()
        {
            var ShipmentDocumentContact = await _mediator.Send(new GetShipmentDocumentsQuery(0));
            return Ok(ShipmentDocumentContact);
        }

        [HttpGet("GetShipmentDocumentById")]
        public async Task<IActionResult> GetShipmentDocumentContactById(int id)
        {
            var ShipmentDocumentContact = await _mediator.Send(new GetShipmentDocumentsQuery(id));
            return Ok(ShipmentDocumentContact);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParasutShipmentDocumentModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new ShipmentDocumentOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParasutShipmentDocumentModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new ShipmentDocumentOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new ParasutShipmentDocumentModel());
            var response = await _mediator.Send(new ShipmentDocumentOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }
    }
}

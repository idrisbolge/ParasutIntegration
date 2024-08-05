using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Enums;
using ParasutIntegration.Features.Offer.Commands;
using ParasutIntegration.Features.SalesInvoice.Commands;
using ParasutIntegration.Features.SalesInvoice.Queries;
using ParasutIntegration.Models.SalesInvoice;
using ParasutIntegration.Util;
using System.Reflection;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/SalesInvoice")]
    [ApiController]

    public class SalesInvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesInvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllSalesInvoice")]
        public async Task<IActionResult> GetAllSalesInvoiceContact()
        {
            var SalesInvoiceContact = await _mediator.Send(new GetSalesInvoicesQuery(0));
            return Ok(SalesInvoiceContact);
        }

        [HttpGet("GetSalesInvoiceById")]
        public async Task<IActionResult> GetSalesInvoiceContactById(int id)
        {
            var SalesInvoiceContact = await _mediator.Send(new GetSalesInvoicesQuery(id));
            return Ok(SalesInvoiceContact);
        }


        [HttpPost]
        public async Task<IActionResult> Post(ParasutSalesInvoiceModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new SalesInvoiceOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParasutSalesInvoiceModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new SalesInvoiceOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new ParasutSalesInvoiceModel());
            var response = await _mediator.Send(new SalesInvoiceOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }


        [HttpPost("Pay")]
        public async Task<IActionResult> PDF(ParasutSalesInvoicePayRequestModel model, int invoiceId)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(invoiceId.ToString(), model);
            var response = await _mediator.Send(new SalesInvoicePayCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpDelete("Cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var response = await _mediator.Send(new SalesInvoiceCancelCommands(id));
            return Ok(response);
        }
        
        [HttpPatch("Recover")]
        public async Task<IActionResult> UpdateStatus(int SalesInvoiceId)
        {

            var response = await _mediator.Send(new SalesInvoiceRecoverCommands(SalesInvoiceId));
            return Ok(response);
        }

        [HttpPatch("Archive")]
        public async Task<IActionResult> Archive(int SalesInvoiceId)
        {
            var response = await _mediator.Send(new SalesInvoiceArchiveCommands(true, SalesInvoiceId));
            return Ok(response);
        }

        [HttpPatch("Unarchive")]
        public async Task<IActionResult> Unarchive(int SalesInvoiceId)
        {
            var response = await _mediator.Send(new SalesInvoiceArchiveCommands(false, SalesInvoiceId));
            return Ok(response);
        }



        
    }
}

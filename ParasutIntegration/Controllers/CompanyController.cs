using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Company.Commands;
using ParasutIntegration.Features.Company.Queries;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/company")]
    [ApiController]

    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCompanyId")]
        public async Task<IActionResult> GetCompanyId()
        {
            var companyId = await _mediator.Send(new GetCompanyIdQuery());
            return Ok(companyId);
        }

        [HttpGet("GetAllCompanyContact")]
        public async Task<IActionResult> GetAllCompanyContact()
        {
            var companyContact = await _mediator.Send(new GetCompanyContactQuery());
            return Ok(companyContact);
        }

        [HttpGet("GetCompanyContactById")]
        public async Task<IActionResult> GetCompanyContactById(int id)
        {
            var companyContact = await _mediator.Send(new GetCompanyContactQuery(id));
            return Ok(companyContact);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyContactRequestModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new CompanyOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CompanyContactRequestModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new CompanyOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new CompanyContactRequestModel());
            var response = await _mediator.Send(new CompanyOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }

        [HttpPost("Debit")]
        public async Task<IActionResult> Debit(ParasutTransactionModel model, string ContactId)
        {

            var parameters = ParasutRequestFactory.CreateRequestModel(ContactId, model);
            var response = await _mediator.Send(new CompanyDebitOrCreditCommands(parameters, HttpMethod.Post, 'D'));
            return Ok(response);
        }
        [HttpPost("Credit")]
        public async Task<IActionResult> Credit(ParasutTransactionModel model, string ContactId)
        {

            var parameters = ParasutRequestFactory.CreateRequestModel(ContactId, model);
            var response = await _mediator.Send(new CompanyDebitOrCreditCommands(parameters, HttpMethod.Post, 'C'));
            return Ok(response);
        }
    }
}

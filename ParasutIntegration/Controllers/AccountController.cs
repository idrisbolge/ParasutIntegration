using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Account.Commands;
using ParasutIntegration.Features.Account.Queries;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Models.Company;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/Account")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAllAccountContact()
        {
            var AccountContact = await _mediator.Send(new GetAccountsQuery(id: 0));
            return Ok(AccountContact);
        }

        [HttpGet("GetAccountById")]
        public async Task<IActionResult> GetAccountContactById(int id)
        {
            var AccountContact = await _mediator.Send(new GetAccountsQuery(id: id));
            return Ok(AccountContact);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new AccountOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AccountModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new AccountOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new AccountModel());
            var response = await _mediator.Send(new AccountOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }

        [HttpPost("Debit")]
        public async Task<IActionResult> Debit(ParasutTransactionModel model, string AccountId)
        {

            var parameters = ParasutRequestFactory.CreateRequestModel(AccountId, model);
            var response = await _mediator.Send(new AccountDebitOrCreditCommands(parameters, HttpMethod.Post, 'D'));
            return Ok(response);
        }
        [HttpPost("Credit")]
        public async Task<IActionResult> Credit(ParasutTransactionModel model, string ContactId)
        {

            var parameters = ParasutRequestFactory.CreateRequestModel(ContactId, model);
            var response = await _mediator.Send(new AccountDebitOrCreditCommands(parameters, HttpMethod.Post, 'C'));
            return Ok(response);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Company.Queries;

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


    }
}

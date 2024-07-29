using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Auth.Commands;
using ParasutIntegration.Models.Token;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/auth")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel parameters)
        {
            var token = await _mediator.Send(new GetTokenCommands(parameters));
            return Ok(token);
        }
    }
}

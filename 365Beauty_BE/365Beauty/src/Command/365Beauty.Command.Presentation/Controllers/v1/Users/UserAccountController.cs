using _365Beauty.Command.Application.Commands.Users.UserAccounts;
using _365Beauty.Command.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userAccount")]
    public class UserAccountController : ApiController
    {
        private readonly IMediator mediator;

        public UserAccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAccount([FromBody] RegisterUserAccountCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAccount([FromBody] LoginUserAccountCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
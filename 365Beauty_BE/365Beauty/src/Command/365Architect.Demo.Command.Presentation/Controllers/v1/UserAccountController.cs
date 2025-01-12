using _365Beauty.Command.Application.Commands.UserAccounts;
using _365Beauty.Command.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1
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

        [HttpPost]
        public async Task<IActionResult> CreateUserAccountV1([FromBody] CreateUserAccountCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
using _365Beauty.Command.Application.Commands.Users.UserImformations;
using _365Beauty.Command.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userInformation")]
    [Authorize]
    public class UserInformationController : ApiController
    {
        private readonly IMediator mediator;

        public UserInformationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUserImfomation([FromBody] UpdateUserInformationCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
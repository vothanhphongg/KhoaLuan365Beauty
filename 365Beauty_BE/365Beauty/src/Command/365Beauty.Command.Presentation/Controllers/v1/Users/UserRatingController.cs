using _365Beauty.Command.Application.Commands.Users.UserRatings;
using _365Beauty.Command.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userRating")]
    [Authorize]
    public class UserRatingController : ApiController
    {
        private readonly IMediator mediator;

        public UserRatingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRating([FromBody] CreateUserRatingQuery command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
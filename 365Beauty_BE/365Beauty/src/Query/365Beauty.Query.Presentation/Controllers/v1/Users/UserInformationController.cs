using _365Beauty.Query.Application.Queries.Users.UserInformations;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userInformations")]
    public class UserInformationController : ApiController
    {
        private readonly IMediator mediator;

        public UserInformationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDetailUserInformation(int userId)
        {
            var query = new GetDetailUserInformationQuery()
            {
                UserId = userId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
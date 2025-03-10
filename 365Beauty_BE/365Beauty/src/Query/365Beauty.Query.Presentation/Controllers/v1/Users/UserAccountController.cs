using _365Beauty.Query.Application.Queries.Users.UserAccounts;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Queries.Users.UserAccounts;

namespace _365Beauty.Query.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}")]
    public class UserAccountController : ApiController
    {
        private readonly IMediator mediator;

        public UserAccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("userAccounts")]
        public async Task<IActionResult> GetAllUserAccounts()
        {
            var query = new GetAllUserAccountsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("staffAccounts")]
        public async Task<IActionResult> GetAllStaffAccounts()
        {
            var query = new GetAllStaffAccountQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
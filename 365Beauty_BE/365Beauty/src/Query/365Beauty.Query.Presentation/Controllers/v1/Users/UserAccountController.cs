using _365Beauty.Query.Application.Queries.UserAccounts;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userAccounts")]
    public class UserAccountController : ApiController
    {
        private readonly IMediator mediator;

        public UserAccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAccounts()
        {
            var query = new GetAllUserAccountsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
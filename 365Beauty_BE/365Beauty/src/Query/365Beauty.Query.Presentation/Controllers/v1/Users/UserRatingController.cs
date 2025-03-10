using _365Beauty.Query.Application.Queries.Users.UserRatings;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userRatings")]
    public class UserRatingController : ApiController
    {
        private readonly IMediator mediator;

        public UserRatingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{salonServiceId}")]
        public async Task<IActionResult> GetAllUserRatings(int salonServiceId)
        {
            var query = new GetAllUSerRatingQuery
            {
                SalonServiceId = salonServiceId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
using _365Beauty.Query.Application.Queries.Users.UserBookings;
using _365Beauty.Query.Application_Queries.Users.UserBookings;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userBookings")]
    public class UserBookingController : ApiController
    {
        private readonly IMediator mediator;

        public UserBookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailUserBooking(int id)
        {
            var query = new GetDetailUserBookingQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllUserBookingActived([FromQuery] GetAllUserBookingActivedByUserIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("salon")]
        public async Task<IActionResult> GetAllUserBookingBySalonId([FromQuery] GetAllUserBookingBySalonIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
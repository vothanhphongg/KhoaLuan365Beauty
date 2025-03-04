using _365Beauty.Query.Application.Queries.Bookings.Bookings;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/bookings")]
    public class BookingController : ApiController
    {
        private readonly IMediator mediator;

        public BookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("bookingTimes")]
        public async Task<IActionResult> GetAllBookingTimesByBookingDate([FromQuery] GetAllBookingTimesByBookingDateQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
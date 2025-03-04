using _365Beauty.Query.Application.Queries.Bookings.BookingTypes;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/bookingTypes")]
    public class BookingTypeController : ApiController
    {
        private readonly IMediator mediator;

        public BookingTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBookingTypes()
        {
            var query = new GetAllBookingTypeQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBookingType(int id)
        {
            var query = new GetDetailBookingTypeQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
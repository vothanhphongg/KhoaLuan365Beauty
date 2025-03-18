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
        [HttpGet("byUserId")]
        public async Task<IActionResult> GetAllUserBooking([FromQuery] GetAllUserBookingByUserIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("bySalonId")]
        public async Task<IActionResult> GetAllUserBookingBySalonId([FromQuery] GetAllUserBookingBySalonIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("count/bySalonId/{salonId}")]
        public async Task<IActionResult> GetCountUserBookingBySalonId(int salonId)
        {
            var query = new GetCountUserBookingBySalonIdQuery
            {
                SalonId = salonId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("count/bySalonServiceId/{salonServiceId}")]
        public async Task<IActionResult> GetCountUserBookingBySalonServiceId(int salonServiceId)
        {
            var query = new GetCountUserBookingBySalonServiceIdQuery
            {
                SalonServiceId = salonServiceId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCountUserBooking()
        {
            var query = new GetCountUserBookingQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
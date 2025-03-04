using _365Beauty.Command.Application.Commands.Bookings.BookingTypes;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/bookingType")]
    [Authorize(Policy = Role.ADMIN)]
    public class BookingTypeController : ApiController
    {
        private readonly IMediator mediator;

        public BookingTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingType([FromBody] CreateBookingTypeCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBookingType([FromBody] UpdateBookingTypeCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingType(int id)
        {
            var command = new DeleteBookingTypeCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
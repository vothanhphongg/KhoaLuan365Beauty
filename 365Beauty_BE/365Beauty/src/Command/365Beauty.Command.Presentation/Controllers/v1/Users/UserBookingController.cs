using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Users
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/userBooking")]
    public class UserBookingController : ApiController
    {
        private readonly IMediator mediator;

        public UserBookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> CreateUserBooking([FromBody] CreateUserBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut()]
        public async Task<IActionResult> UpdateUserBooking([FromBody] UpdateUserBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [Authorize(Policy = Role.BEAUTY_SALON)]
        [HttpPost("confirm_success")]
        public async Task<IActionResult> ConfirmSuccessUserBooking([FromBody] ConfirmSuccessUserBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
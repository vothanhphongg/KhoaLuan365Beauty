using _365Beauty.Command.Application.Commands.BeautySalons.PriceAndBookings;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.v1.BeautySalons
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/priceAndBooking")]
    [Authorize(Policy = Role.BEAUTY_SALON)]
    public class PriceAndBookingController : ApiController
    {
        private readonly IMediator mediator;

        public PriceAndBookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePriceAndBooking([FromBody] CreatePriceAndBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePriceAndBooking([FromBody] UpdatePriceAndBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

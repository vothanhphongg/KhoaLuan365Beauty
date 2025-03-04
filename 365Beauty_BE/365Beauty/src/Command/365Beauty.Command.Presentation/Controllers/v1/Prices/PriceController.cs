using _365Beauty.Command.Application.Commands.Prices;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Prices
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/price")]
    [Authorize(Policy = Role.BEAUTY_SALON)]
    public class PriceController : ApiController
    {
        private readonly IMediator mediator;

        public PriceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        
        public async Task<IActionResult> CreatePrice([FromBody] CreatePriceBookingCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdatePrice([FromBody] UpdatePriceCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

using _365Beauty.Command.Application.Commands.Bookings.Times;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/time")]
    [Authorize(Policy = Role.ADMIN)]
    public class TimeController : ApiController
    {
        private readonly IMediator mediator;

        public TimeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTime([FromBody] CreateTimeCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTime([FromBody] UpdateTimeCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime(int id)
        {
            var command = new DeleteTimeCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
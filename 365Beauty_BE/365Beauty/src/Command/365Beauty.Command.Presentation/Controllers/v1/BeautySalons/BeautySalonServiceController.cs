using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonServices;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.BeautySalons
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/beautySalonService")]
    [Authorize(Roles = $"{Role.ADMIN}, {Role.BEAUTY_SALON}")]

    public class BeautySalonServiceController : ApiController
    {
        private readonly IMediator mediator;

        public BeautySalonServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBeautySalonService([FromBody] CreateBeautySalonServiceCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBeautySalonService([FromBody] UpdateBeautySalonServiceCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> LockOrUnLockBeautySalonService(int id)
        {
            var command = new LockOrUnLockBeautySalonServiceCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
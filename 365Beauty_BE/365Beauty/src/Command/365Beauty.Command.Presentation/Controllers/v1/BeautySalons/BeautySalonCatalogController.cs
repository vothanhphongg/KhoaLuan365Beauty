using _365Beauty.Command.Application.Commands.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.BeautySalons
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/beautySalonCatalog")]
    public class BeautySalonCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public BeautySalonCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = Role.ADMIN)]
        public async Task<IActionResult> CreateBeautySalonCatalog([FromBody] CreateBeautySalonCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        [Authorize(Roles = $"{Role.ADMIN}, {Role.BEAUTY_SALON}")]
        public async Task<IActionResult> UpdateBeautySalonCatalog([FromBody] UpdateBeautySalonCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Role.ADMIN)]
        public async Task<IActionResult> LockOrUnLockBeautySalonCatalog(int id)
        {
            var command = new LockOrUnLockBeautySalonCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
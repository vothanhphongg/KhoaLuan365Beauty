using _365Beauty.Command.Application.Commands.Services;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Services
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/serviceCatalog")]
    [Authorize(Policy = Role.ADMIN)]
    public class ServiceCatalogsController : ApiController
    {
        private readonly IMediator mediator;

        public ServiceCatalogsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCatalog([FromBody] CreateServiceCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServiceCatalog([FromBody] UpdateServiceCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> LockOrUnLockServiceCatalog(int id)
        {
            var command = new LockOrUnLockServiceCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
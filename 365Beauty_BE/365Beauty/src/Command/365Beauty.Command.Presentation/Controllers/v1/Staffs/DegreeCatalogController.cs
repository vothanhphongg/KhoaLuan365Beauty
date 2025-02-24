using _365Beauty.Command.Application.Commands.Staffs.DegreeCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/degreeCatalog")]
    [Authorize(Policy = Role.ADMIN)]
    public class DegreeCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public DegreeCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDegreeCatalog([FromBody] CreateDegreeCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBeautySalonCatalog([FromBody] UpdateDegreeCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeautySalonCatalog(int id)
        {
            var command = new DeleteDegreeCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

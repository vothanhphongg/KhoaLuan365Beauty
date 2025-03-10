using _365Beauty.Command.Application.Commands.Staffs.TitleCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/titleCatalog")]
    [Authorize(Policy = Role.ADMIN)]
    public class TitleCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public TitleCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitleCatalog([FromBody] CreateTitleCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTitleCatalog([FromBody] UpdateTitleCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitleCatalog(int id)
        {
            var command = new DeleteTitleCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
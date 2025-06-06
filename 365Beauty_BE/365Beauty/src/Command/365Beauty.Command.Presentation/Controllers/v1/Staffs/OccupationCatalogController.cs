﻿using _365Beauty.Command.Application.Commands.Staffs.OccupationCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/occupationCatalog")]
    [Authorize(Policy = Role.ADMIN)]
    public class OccupationCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public OccupationCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOccupationCatalog([FromBody] CreateOccupationCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOccupationCatalog([FromBody] UpdateOccupationCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupationCatalog(int id)
        {
            var command = new DeleteOccupationCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
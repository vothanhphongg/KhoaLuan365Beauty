using _365Beauty.Command.Application.Commands.BeautySalonCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Command.Presentation.DTOs.BeautySalonCatalogRequestDTOs;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Architect.Demo.Command.Presentation.Controllers.v1
{
    /// <summary>
    /// Controller version 1 for order apis
    /// </summary>
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
        public async Task<IActionResult> CreateBeautySalonCatalogV1([FromBody] CreateBeautySalonCatalogRequest request)
        {
            var command = new CreateBeautySalonCatalogCommand()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Content = request.Content,
                Email = request.Email,
                Website = request.Website,
                Tel = request.Tel,
                Image = request.Image,
                WorkingDate = request.WorkingDate,
                Address = request.Address,
                WardId = request.WardId,
                UserIdCreated = request.UserIdCreated,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBeautySalonCatalogV1(int id, [FromBody] UpdateBeautySalonCatalogRequest request)
        {
            var command = new UpdateBeautySalonCatalogCommand()
            {
                Id = id,
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Content = request.Content,
                Email = request.Email,
                Website = request.Website,
                Tel = request.Tel,
                Image = request.Image,
                WorkingDate = request.WorkingDate,
                Address = request.Address,
                WardId = request.WardId,
                UserIdUpdated = request.UserIdUpdated,
                IsActived = request.IsActived,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBeautySalonCatalogV1(int id)
        {
            var command = new DeleteBeautySalonCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
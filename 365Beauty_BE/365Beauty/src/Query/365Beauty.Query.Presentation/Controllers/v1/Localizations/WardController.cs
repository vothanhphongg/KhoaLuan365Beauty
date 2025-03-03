using _365Beauty.Query.Application.Queries.Localizations.Wards;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Localizations
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/localization/wards")]
    public class WardController : ApiController
    {
        private readonly IMediator mediator;

        public WardController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWardByDistrictIdCatalogs([FromQuery] GetAllWardByDistrictIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailWard(string id)
        {
            var query = new GetDetailWardQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

    }
}
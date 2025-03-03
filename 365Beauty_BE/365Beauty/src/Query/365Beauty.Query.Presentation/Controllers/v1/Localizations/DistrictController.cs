using _365Beauty.Query.Application.Queries.Localizations.Districts;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Localizations
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/localization/districts")]
    public class DistrictController : ApiController
    {
        private readonly IMediator mediator;

        public DistrictController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDistrictsByProvinceId([FromQuery] GetAllDistrictByProvinceIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailDistrict(string id)
        {
            var query = new GetDetailDistrictQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
using _365Beauty.Query.Application.Queries.Localizations.Provinces;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Localizations
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/localization/provinces")]
    public class ProvinceController : ApiController
    {
        private readonly IMediator mediator;

        public ProvinceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProvinces()
        {
            var query = new GetAllProvinceQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailProvince( string id)
        {
            var query = new GetDetailProvinceQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

    }
}
using _365Beauty.Query.Application.Queries.Staffs.OccuptionCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/occupationCatalogs")]
    public class OccupationCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public OccupationCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOccupationCatalogs()
        {
            var query = new GetAllOccupationCatalogQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailOccupationCatalog(int id)
        {
            var query = new GetDetailOccupationCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
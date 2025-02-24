using _365Beauty.Query.Application.Queries.Staffs.DegreeCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/degreeCatalogs")]
    public class DegreeCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public DegreeCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDegreeCatalogs()
        {
            var query = new GetAllDegreeCatalogQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailDegreeCatalog(int id)
        {
            var query = new GetDetailDegreeCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
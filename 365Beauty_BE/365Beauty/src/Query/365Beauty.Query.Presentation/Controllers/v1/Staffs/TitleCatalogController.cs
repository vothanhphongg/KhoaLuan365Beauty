using _365Beauty.Query.Application.Queries.Staffs.TitleCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/titleCatalogs")]
    public class TitleCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public TitleCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTitleCatalogs()
        {
            var query = new GetAllTitleCatalogQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailTitleCatalog(int id)
        {
            var query = new GetDetailTitleCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
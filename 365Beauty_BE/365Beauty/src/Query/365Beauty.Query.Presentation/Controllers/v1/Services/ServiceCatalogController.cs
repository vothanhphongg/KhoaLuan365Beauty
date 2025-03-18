using _365Beauty.Query.Application.Queries.ServiceCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Services
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/serviceCatalogs")]
    public class ServiceCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public ServiceCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllServiceCatalogs([FromQuery] GetAllServiceCatalogsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailServiceCatalog(int id)
        {
            var query = new GetDetailServiceCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
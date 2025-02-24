using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Query.ApplicationQueries.BeautySalons.BeautySalonCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.BeautySalons
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/beautySalonCatalogs")]
    public class BeautySalonCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public BeautySalonCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBeautySalonCatalog(int id)
        {
            var query = new GetDetailBeautySalonCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeautySalonCatalogs([FromQuery] GetAllBeautySalonCatalogsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
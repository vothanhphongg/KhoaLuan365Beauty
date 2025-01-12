using _365Beauty.Query.Application.Queries.BeautySalonCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1
{
    /// <summary>
    /// Controller version 1 for sample apis
    /// </summary>
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/beautySalonCatalogs")]
    public class BeautySalonCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public BeautySalonCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Api version 1 for get sample by id
        /// </summary>
        /// <param name="id">ID of sample</param>
        /// <returns>Action result with sample as data</returns>
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSampleByIdV1(int id)
        {
            var query = new GetDetailBeautySalonCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Api version 1 for get all samples
        /// </summary>
        /// <returns>Action result with list of samples as data</returns>
        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllSamplesV1()
        {
            var query = new GetAllBeautySalonCatalogQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
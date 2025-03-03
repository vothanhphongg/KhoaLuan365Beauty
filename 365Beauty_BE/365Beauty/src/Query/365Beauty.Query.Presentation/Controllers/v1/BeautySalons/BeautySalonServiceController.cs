using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.BeautySalons
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/beautySalonServices")]
    public class BeautySalonServiceController : ApiController
    {
        private readonly IMediator mediator;

        public BeautySalonServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBeautySalonServiceBySalonId([FromQuery] GetAllBeautySalonServiceBySalonIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("withPrice")]
        public async Task<IActionResult> GetAllBeautySalonServiceWithPrices()
        {
            var query = new GetAllBeautySalonServiceWithPriceQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBeautySalonService(int id)
        {
            var query = new GetDetailBeautySalonServiceQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getAll/{serviceId}")]
        public async Task<IActionResult> GetAllBeautySalonServiceByServiceId(int serviceId)
        {
            var query = new GetAllBeautySalonServieByServiceIdQuery
            {
                ServiceId = serviceId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
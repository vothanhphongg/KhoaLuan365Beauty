using _365Beauty.Query.Application.Queries.Bookings.Times;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/times")]
    public class TimeController : ApiController
    {
        private readonly IMediator mediator;

        public TimeController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTimes()
        {
            var query = new GetAllTimeQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailTime(int id)
        {
            var query = new GetDetailTimeQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
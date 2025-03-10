using _365Beauty.Query.Application.Queries.Bookings.HistoryTransactions;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/historyTransactions")]
    public class HistoryTransactionController : ApiController
    {
        private readonly IMediator mediator;

        public HistoryTransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHistoryTransactions()
        {
            var query = new GetAllHistoryTransactionQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
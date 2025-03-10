using _365Beauty.Command.Application.Commands.Staffs.StaffCatalogs;
using _365Beauty.Command.Presentation.Abstractions;
using _365Beauty.Contract.Constants;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/staffCatalog")]
    [Authorize(Roles = $"{Role.ADMIN}, {Role.BEAUTY_SALON}")]
    public class StaffCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public StaffCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffCatalog([FromBody] CreateStaffCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaffCatalog([FromBody] UpdateStaffCatalogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> LockOrUnLockStaffCatalog(int id)
        {
            var command = new LockOrUnLockStaffCatalogCommand()
            {
                Id = id,
            };

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
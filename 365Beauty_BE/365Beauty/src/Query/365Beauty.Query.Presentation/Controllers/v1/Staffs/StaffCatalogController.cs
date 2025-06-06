﻿using _365Beauty.Query.Application.Queries.Staffs.StaffCatalogs;
using _365Beauty.Query.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Query.Presentation.Controllers.v1.Staffs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/staffCatalogs")]
    public class StaffCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public StaffCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailStaffCatalog(int id)
        {
            var query = new GetDetailStaffCatalogQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("bySalonServiceId")]
        public async Task<IActionResult> GetAllStaffCatalogBySalonServiceId([FromQuery] GetAllStaffCatalogByBeautySalonServiceIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("bySalonId/{salonId}")]
        public async Task<IActionResult> GetAllStaffCatalogBySalonId(int salonId)
        {
            var query = new GetAllStaffCatalogBySalonIdQuery
            {
                SalonId = salonId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}

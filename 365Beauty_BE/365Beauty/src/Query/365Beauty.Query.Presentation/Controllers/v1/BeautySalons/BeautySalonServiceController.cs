﻿using _365Beauty.Query.Application.Queries.BeautySalons.BeautySalonServices;
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
        public async Task<IActionResult> GetAllBeautySalonServices()
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

        [HttpGet("bySalonId")]
        public async Task<IActionResult> GetAllBeautySalonServiceBySalonId([FromQuery] GetAllBeautySalonServiceBySalonIdQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("bySalonId/{salonId}")]
        public async Task<IActionResult> GetAllBeautySalonServiceFullBySalonId(int salonId)
        {
            var query = new GetAllBeautySalonServiceFullBySalonIdQuery
            {
                SalonId = salonId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("byServiceId/{serviceId}")]
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
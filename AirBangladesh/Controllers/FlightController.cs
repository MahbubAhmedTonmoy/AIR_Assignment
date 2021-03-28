using Application.Command;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBangladesh.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        ILogger<FlightController> _log;
        public FlightController(IMediator mediator, ILogger<FlightController> log)
        {
            _mediator = mediator;
            _log = log;
        }

        [HttpGet]
        public string Ping()
        {
            _log.LogInformation("enter ping");
            return "Pong";
        }

        [HttpPost("CreateFlight")]
        //[ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateFlight([FromBody] FlightCreateCommand flightCreateCommand)
        {
            _log.LogInformation("enter CreateFlight contromller");
            var orders = await _mediator.Send(flightCreateCommand);
            return Ok(orders);
        }
        [HttpPost("AllFlights")]
        //[ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AllFlights([FromBody]GetAllFlightQuery getAllFlightQuery)
        {
            _log.LogInformation("enter get AllFlights contromller");
            var orders = await _mediator.Send(getAllFlightQuery);
            return Ok(orders);
        }
    }
}

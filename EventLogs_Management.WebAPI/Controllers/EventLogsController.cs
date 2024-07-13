using EventLogs_Management.Core.AggregationRoots;
using EventLogs_Management.Core.Enums;
using EventLogs_Management.Core.Models;
using EventLogs_Management.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventLogs_Management.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly IEventLogsDomain? _eventLogs;

        public EventLogsController(ILogger<EventLogsController> logger, IEventLogsDomain eventLogsDomain)
        {  
            _eventLogs = eventLogsDomain;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventLog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<EventLog>>> GetLogs()
        {
            var result = await _eventLogs!.GetLogList();

            return Ok(result);
        }

        [HttpPost("DateFilter")]
        [ProducesResponseType(typeof(IEnumerable<EventLog>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<ActionResult<List<EventLog>>> DateFilter([FromBody] DateFilter input)
        {
            var result = await _eventLogs!.DateFilter(input);

            return Ok(result);
        }

        [HttpGet("EventFilter")]
        [ProducesResponseType(typeof(IEnumerable<EventLog>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<ActionResult<List<EventLog>>> EventFilter(EventEnum @event)
        {
            var result = await _eventLogs!.EventFilter(new() { EventType = @event.ToString() });

            return Ok(result);
        }

        [HttpPost("DateAndEventFilter")]
        [ProducesResponseType(typeof(IEnumerable<EventLog>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<ActionResult<List<EventLog>>> DateAndEventFilter([FromBody] DateFilter input, EventEnum @event)
        {
            var result = await _eventLogs!.DateAndEventFilter(input, new() { EventType = @event.ToString() });

            return Ok(result);
        }

        [HttpPost("SaveEvent")]
        [ProducesResponseType(typeof(EventLog), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<ActionResult<EventLog>> SaveEvent([FromBody] EventLog input)
        {

            if (!input.EventType!.IsEnumValue<EventEnum>()) 
                return BadRequest(new { message = "Invalid Event type."});

            var result = await _eventLogs!.Save(input);

            return Ok(result);
        }
    }
}
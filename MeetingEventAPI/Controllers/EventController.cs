using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingEventAPI.Services;
using AutoMapper;
using MeetingEventAPI.Entities;
using MeetingEventAPI.Models;

namespace MeetingEventAPI.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateEventDto dto, [FromRoute] int id)
        {
            var isUpdated =_eventService.Update(id, dto);
            if (isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _eventService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateEvent([FromBody] CreateEventDto dto)
        {
            var id = _eventService.Create(dto);
            return Created($"/api/event/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {

            var events = _eventService.GetAll();
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<EventDto> Get([FromRoute] int id)
        {
            var events = _eventService.GetById(id);
            if (events is null)
            {
                return NotFound();
            }
            
            return Ok(events);
        }
        
    }
}

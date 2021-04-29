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
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;


        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePersonDto dto, [FromRoute] int id)
        {
            var isUpdated = _personService.Update(id, dto);
            if (isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _personService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreatePerson([FromBody] CreatePersonDto dto)
        {
            var id = _personService.Create(dto);
            return Created($"/api/event/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {

            var people = _personService.GetAll();
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<PersonDto> Get([FromRoute] int id)
        {
            var people = _personService.GetById(id);
            if (people is null)
            {
                return NotFound();
            }

            return Ok(people);
        }

    }
}
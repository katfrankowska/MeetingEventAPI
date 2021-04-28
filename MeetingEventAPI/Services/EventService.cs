using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingEventAPI.Models;
using MeetingEventAPI.Entities;
using AutoMapper;
using MeetingEventAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MeetingEventAPI.Services
{
    public interface IEventService
    {
        EventDto GetById(int id);
        IEnumerable<EventDto> GetAll();
        int Create(CreateEventDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateEventDto dto);
    }

    public class EventService : IEventService
    {
        private readonly EventDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventService(EventDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Update(int id, UpdateEventDto dto)
        {
            var events = _dbContext
                .Events
                .FirstOrDefault(e => e.Id == id);
            if (events is null)
                return false;
            events.Name = dto.Name;
            events.Description = dto.Description;
            events.Date = dto.Date;
            _dbContext.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var events = _dbContext
                .Events
                .FirstOrDefault(e => e.Id == id);
            if (events is null) return false;
            _dbContext.Events.Remove(events);
            _dbContext.SaveChanges();
            return true;
        }

        public EventDto GetById(int id)
        {
            var events = _dbContext
                .Events
                .FirstOrDefault(e => e.Id == id);
            if (events is null) return null;
            var result = _mapper.Map<EventDto>(events);
            return result;
        }

        public IEnumerable<EventDto> GetAll()
        {
            var events = _dbContext
                .Events
                .ToList();
            var eventsDtos = _mapper.Map<List<EventDto>>(events);
            return eventsDtos;

        }

        public int Create(CreateEventDto dto)
        {
            var events = _mapper.Map<Event>(dto);
            _dbContext.Events.Add(events);
            _dbContext.SaveChanges();
            return events.Id;
        }
      

       
    }
}

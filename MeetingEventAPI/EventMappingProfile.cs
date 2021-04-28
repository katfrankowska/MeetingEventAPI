using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingEventAPI.Entities;
using MeetingEventAPI.Models;
using MeetingEventAPI.Controllers;
using AutoMapper;

namespace MeetingEventAPI
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<CreateEventDto, Event>();
            CreateMap<CreatePersonDto, Event>();
        }
    }
}

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
    public interface IPersonService
    {
        PersonDto GetById(int id);
        IEnumerable<PersonDto> GetAll();
        int Create(CreatePersonDto dto);
        bool Delete(int id);
        bool Update(int id, UpdatePersonDto dto);
    }

    public class PersonService : IPersonService
    {
        private readonly EventDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonService(EventDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Update(int id, UpdatePersonDto dto)
        {
            var people = _dbContext
                .People
                .FirstOrDefault(e => e.Id == id);
            if (people is null)
                return false;
            people.Name = dto.Name;
            people.Surname = dto.Surname;
            people.Email = dto.Email;
            people.BirthDate = dto.BirthDate;
            _dbContext.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var people = _dbContext
                .People
                .FirstOrDefault(e => e.Id == id);
            if (people is null) return false;
            _dbContext.People.Remove(people);
            _dbContext.SaveChanges();
            return true;
        }

        public PersonDto GetById(int id)
        {
            var people = _dbContext
                .People
                .FirstOrDefault(e => e.Id == id);
            if (people is null) return null;
            var result = _mapper.Map<PersonDto>(people);
            return result;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var people = _dbContext
                .People
                .ToList();
            var peopleDtos = _mapper.Map<List<PersonDto>>(people);
            return peopleDtos;

        }

        public int Create(CreatePersonDto dto)
        {
            var people = _mapper.Map<Person>(dto);
            _dbContext.People.Add(people);
            _dbContext.SaveChanges();
            return people.Id;
        }



    }
}


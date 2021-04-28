using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingEventAPI.Entities;

namespace MeetingEventAPI.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

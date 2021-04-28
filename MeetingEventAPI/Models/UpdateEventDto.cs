using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingEventAPI.Entities;

namespace MeetingEventAPI.Models
{
    public class UpdateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}

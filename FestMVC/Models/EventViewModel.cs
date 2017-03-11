using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class EventViewModel:Event
    {
        
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public EventViewModel() { }

        public EventViewModel(long id, string name, string description, long festivalId, long instructorId, long roomId, DateTime startDate, DateTime endDate, Festival festival, Room room, Instructor instructor) : base(id, name, description, festivalId, instructorId, roomId, startDate)
        {
            Festival = festival;
            Room = room;
            Instructor = instructor;
            StartTime = StartTime.Add(startDate.TimeOfDay);
            EndTime = EndTime.Add(endDate.TimeOfDay);
        }
    }
}
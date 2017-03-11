using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class EventViewModel:Event
    {
        //public EventViewModel(long id, string name, string description, long festivalId, long instructorId, long roomId, DateTime startDate, DateTime startTime, DateTime endTime) : base(id, name, description, festivalId, instructorId, roomId, startDate, startTime, endTime)
        //{
        //}
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    

    
    }
}
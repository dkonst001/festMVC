using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Event
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Event Name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Festival")]
        public long FestivalId { get; set; }
        [DisplayName("Instructor")]
        public long InstructorId { get; set; }
        [DisplayName("Room")]
        public long RoomId { get; set; }
        [NotMapped]
        public bool Enrolled { get; set; }

        public virtual Festival Festival { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<EventImage> EventImages { get; set; }


        public Event() { }
        public Event(long id, string name, string description, long festivalId, long instructorId,
                    long roomId, DateTime startDate, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            Description = description;
            FestivalId = festivalId;
            InstructorId = instructorId;
            RoomId = roomId;
            StartDate = startDate;
            EndDate = startDate;
            StartDate=StartDate.Add(startTime.TimeOfDay);
            if (startTime > endTime) { EndDate.AddDays(1); }
            EndDate=EndDate.Add(endTime.TimeOfDay);
        }

        public Event(long id, string name, string description, long festivalId, long instructorId,
                    long roomId, DateTime startDate)
        {
            Id = id;
            Name = name;
            Description = description;
            FestivalId = festivalId;
            InstructorId = instructorId;
            RoomId = roomId;
            StartDate = startDate;
        }
    }
}
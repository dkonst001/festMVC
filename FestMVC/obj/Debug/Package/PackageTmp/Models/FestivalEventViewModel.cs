using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class FestivalEventViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EndTime { get; set; }
        public Festival Festival { get; set; }
        public Instructor Instructor { get; set; }
        public Room Room { get; set; }

        public List<string> Images { get; set; }

        public FestivalEventViewModel(long id, string name, string description,
            DateTime startDate, DateTime startTime,DateTime endTime, Festival festival, Instructor instructor, Room room)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            StartTime = startTime;
            EndTime = endTime;
            Festival = festival;
            Instructor = instructor;
            Room = room;
            Images = new List<string>();
        }
    }
}
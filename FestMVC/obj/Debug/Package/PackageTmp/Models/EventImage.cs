using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class EventImage:IbaseModel
    {
        public long Id { get; set; }
        [DisplayName("Image Name")]
        public string Name { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        [DisplayName("Event Name")]
        public long EventId { get; set; }
        public virtual Event Event { get; set; }

        public string getUserID()
        {
            return Event.Festival.FestivalManager.UserId;
        }
    }
}
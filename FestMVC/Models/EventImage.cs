using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class EventImage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public long EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
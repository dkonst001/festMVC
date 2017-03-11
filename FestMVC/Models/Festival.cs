using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Festival
    {
        public long Id { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Festival Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Festival Manager")]
        public long FestivalManagerId  { get; set; }
        public string Description { get; set; }
        public long LocationId { get; set; }
        [Required]
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual FestivalManager FestivalManager { get; set; }
        public virtual Category Category { get; set; }
        public virtual Location Location { get; set; }


    }
}
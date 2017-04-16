using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Festival:IbaseModel
    {
        public long Id { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Festival Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Festival Manager")]
        public long FestivalManagerId  { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Festival Location")]
        public long LocationId { get; set; }
        [Required]
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual FestivalManager FestivalManager { get; set; }
        public virtual Category Category { get; set; }
        public virtual Location Location { get; set; }

        public string getUserID()
        {
            return FestivalManager.UserId ;
        }
    }
}
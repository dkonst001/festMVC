using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Enrollment
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("User")]
        public string UserId { get; set; }
        [Required]
        [DisplayName("Event")]
        public long EventId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Event Event { get; set; }
    }
}
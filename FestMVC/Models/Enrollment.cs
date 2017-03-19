using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Enrollment: BaseEnrollment

    {
        [Required]
        [Editable(false)]
        [DisplayName("Event")]
        public long EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
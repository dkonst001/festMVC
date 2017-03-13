using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class BaseEnrollment
    {

        public long Id { get; set; }
        [Required]
        [DisplayName("User")]
        public string UserId { get; set; }
        public int NumOfTickets { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Instructor
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Instructor Name")]
        public string UserId { get; set; }
        [DataType(DataType.MultilineText)]
        
        public string About { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
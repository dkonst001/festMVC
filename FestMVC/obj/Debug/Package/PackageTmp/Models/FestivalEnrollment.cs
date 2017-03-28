using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class FestivalEnrollment: BaseEnrollment
    {
        [Required]
        [Editable(false)]
        [DisplayName("Festival")]
        public long FestivalId { get; set; }
        public virtual Festival Festival { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class FestivalManager
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
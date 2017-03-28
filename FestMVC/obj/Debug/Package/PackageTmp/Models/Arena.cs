using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Arena
    {
        public long Id { get; set; }
        public long FestivalId { get; set; }
        public virtual Festival Festival { get; set; }
    }
}
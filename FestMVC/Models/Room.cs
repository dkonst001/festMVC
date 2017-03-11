using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long LocationId { get; set; }
        public int Capacity { get; set; }
        public virtual Location Locaytion { get; set; }
    }
}
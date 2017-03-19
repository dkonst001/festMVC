using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Room
    {
        public long Id { get; set; }
        [DisplayName("Hall Name")]
        public string Name { get; set; }
        [DisplayName("Location Name")]
        public long LocationId { get; set; }
        [DisplayName("Hall Capacity")]
        public int Capacity { get; set; }
        public virtual Location Location { get; set; }
    }
}
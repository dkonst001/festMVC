using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Location
    {
        public long Id { get; set; }
        [DisplayName("Location Name")]
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        [DisplayName("Type Of Location")]
        public LocationTypes Type { get; set; }
        public int Size { get; set; }
        [DisplayName("Number of Halls")]
        public int NumberOfHalls { get; set; }
        [DisplayName("Location Map")]
        public string ArenaMapImage { get; set; }

    }
    
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Capacity { get; set; }
        public LocationTypes Type { get; set; }
        public int Size { get; set; }
        public int NumberOfHalls { get; set; }
        public string ArenaMapImage { get; set; }

    }
    
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class HomeCategoryViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }

        public HomeCategoryViewModel(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Images = new List<string>();
        }
    }
}
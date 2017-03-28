using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class CategoryFestivalViewModel
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public FestivalManager FestivalManager { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public Location Location { get; set; }
        [Required]
        
        public Category Category { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }

        public List<string> Images { get; set; }

        public CategoryFestivalViewModel(long id, string name, FestivalManager festivalManager, string description, 
            Location location, Category category, DateTime startDate, DateTime enddate)
        {
            Id = id;
            Name = name;
            FestivalManager = festivalManager;
            Description = description;
            Location = location;
            Category = category;
            StartDate = startDate;
            EndDate = enddate;
            Images = new List<string>();
        }
    }
}
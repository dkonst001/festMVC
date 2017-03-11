using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public virtual ICollection<Festival> Festivals { get; set; }
    }
}
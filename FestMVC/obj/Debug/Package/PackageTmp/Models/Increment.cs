using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class Increment
    {
        [Range(1, 100)]
        public int Number { get; set; }
       
    }
}
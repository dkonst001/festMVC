﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class FestivalManager:IbaseModel
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string getUserID()
        {
            return UserId;
        }
    }
}
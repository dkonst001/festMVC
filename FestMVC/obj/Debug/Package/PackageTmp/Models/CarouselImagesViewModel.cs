using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestMVC.Models
{
    public class CarouselImagesViewModel
    {
        public List<string> Images { get; set; }

        public string CarouselId { get; set; }
        public CarouselImagesViewModel(List<string> images, string carouselId) { Images = images; CarouselId = carouselId; }

    }
}
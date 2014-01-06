using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class HomePageSlider
    {
        public HomePageSlider()
        {
            Images = new List<SliderImage>();
        }
        public bool ShowCaption { get; set; }
        public bool ShowLoader { get; set; }
        public bool Paginate { get; set; }
        public bool HasThumbnails { get; set; }
        public List<BI.ViewModels.SliderImage> Images { get; set; }
    }
}

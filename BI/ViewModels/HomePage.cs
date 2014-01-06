using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class HomePage
    {
        public HomePage()
        {
            HomePageSlider = new HomePageSlider();
        }
        public bool ShowSliderPanel { get; set; }
        public bool ShowMainPanel { get; set; }
        public bool ShowFeaturedPanel { get; set; }
        public bool ShowAccessoryPanel { get; set; }
        public BI.ViewModels.HomePageSlider HomePageSlider { get; set; }
    }
}

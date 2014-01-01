using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.Content
{
    public class ContentManager
    {
        public List<BI.ViewModels.SliderImage> GetHomePageSliderImages()
        {
            List<BI.ViewModels.SliderImage> images = new List<ViewModels.SliderImage>();
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide1.jpg", AltText = "BF Jet" });
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide2.jpg", AltText = "Another BF Jet" });
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide3.jpg", AltText = "Yet another BF jet" });

            return images;
        }

        public List<BI.ViewModels.FeaturedContent> GetFeaturedContent()
        {
            List<BI.ViewModels.FeaturedContent> content = new List<ViewModels.FeaturedContent>();
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon1.png", Title = "Flight Training", Description = "Some Words", Controller = "FlightTraining", Action = "Index" });
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon2.png", Title = "Aircraft Fleet", Description = "Some Words", Controller = "AircraftFleet", Action = "Index" });
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon3.png", Title = "Aircraft Maintenance", Description = "Some Words", Controller = "AircraftMaintenance", Action = "Index" });
            return content;

        }
    }
}

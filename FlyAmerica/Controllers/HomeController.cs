using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flyamerica.Controllers
{
    public class HomeController : flyamerica.Controllers.BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadSlider()
        {
            flyamerica.BI.Content.ContentManager cm = new BI.Content.ContentManager();
            List<flyamerica.BI.ViewModels.SliderImage> model = new List<BI.ViewModels.SliderImage>();
            model = cm.GetHomePageSliderImages();
            return PartialView("Partials/_slider", model);
        }

        public ActionResult LoadFeaturedContent()
        {
            flyamerica.BI.Content.ContentManager cm = new BI.Content.ContentManager();
            List<BI.ViewModels.FeaturedContent> model = new List<BI.ViewModels.FeaturedContent>();
            model = cm.GetFeaturedContent();
            return PartialView("Partials/_FeaturedContent", model);

        }
    }
}

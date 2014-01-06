using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace FlyAmerica.Controllers
{
    public class FlightTrainingController : BaseController
    {
        //
        // GET: /FlightTraining/

        public ActionResult Index()
        {
            return View(JDB.BI.Content.ContentManager.GetFlightTrainingInfo());
        }

        public ActionResult LoadFlightTrainingPrograms()
        {
            
            return PartialView("Partials/_FlightPrograms", JDB.BI.Content.ContentManager.GetFlightTrainingPrograms());

        }

        //
        // GET: /FlightTrainingDetails/

        public ActionResult Program(int ID)
        {
            return View(JDB.BI.Content.ContentManager.GetFlightTrainingProgram(ID));
        }

        public ActionResult GetNews(int ID)
        {
            return PartialView("Partials/_RecentNews", JDB.BI.Content.ContentManager.GetNewsItems(JDB.DAL.Reference.NewsItemTypes.FlightTrainingProgram));

        }

        public ActionResult GetTestimonials(int ID)
        {
            return PartialView("Partials/_Testimonials", JDB.BI.Content.ContentManager.GetTestimonials());
        }




    }
}

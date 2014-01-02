using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flyamerica.Controllers
{
    public class FlightTrainingController : BaseController
    {
        //
        // GET: /FlightTraining/

        public ActionResult Index()
        {
            BI.ViewModels.FlightTraining model = new BI.ViewModels.FlightTraining();
            BI.Content.ContentManager cm = new BI.Content.ContentManager();
            model = cm.GetFlightTrainingInfo();
            return View(model);
        }

        public ActionResult LoadFlightTrainingPrograms()
        {
            List<BI.ViewModels.FlightTrainingProgram> model = new List<BI.ViewModels.FlightTrainingProgram>();
            BI.Content.ContentManager cm = new BI.Content.ContentManager();
            model = cm.GetFlightTrainingPrograms();
            return PartialView("Partials/_FlightPrograms", model);

        }

        //
        // GET: /FlightTrainingDetails/

        public ActionResult Program(int ID)
        {
            BI.Content.ContentManager cm = new BI.Content.ContentManager();
            return View(cm.GetFlightTrainingProgram(ID));
        }



    }
}

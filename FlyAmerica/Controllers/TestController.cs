using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flyamerica.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            DAL.flyamericaEntities _ctx = new DAL.flyamericaEntities(); 

            List<DAL.pilottraining> model = _ctx.pilottrainings.ToList();

            if (model.Count < 1)
            {
                loadTraining();
                model = _ctx.pilottrainings.ToList();
            }

            return View(model);
        }

        private void loadTraining()
        {
            DAL.flyamericaEntities _ctx = new DAL.flyamericaEntities();
            _ctx.pilottrainings.AddObject(new DAL.pilottraining { TrainingName = "Private Pilot", TrainingLongDescription = "Long", TrainingShortDescription = "Short", IsActive = true });
            _ctx.pilottrainings.AddObject(new DAL.pilottraining { TrainingName = "Instrument Rating", TrainingLongDescription = "Long", TrainingShortDescription = "Short", IsActive = true });
            _ctx.pilottrainings.AddObject(new DAL.pilottraining { TrainingName = "Commerical Pilot Certificate", TrainingLongDescription = "Long", TrainingShortDescription = "Short", IsActive = true });
            _ctx.pilottrainings.AddObject(new DAL.pilottraining { TrainingName = "Complex Endorsements", TrainingLongDescription = "Long", TrainingShortDescription = "Short", IsActive = true });

            _ctx.SaveChanges();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDB;

namespace FlyAmerica.Controllers
{
    public class InstructorsController : FlyAmerica.Controllers.BaseController
    {
        //
        // GET: /Instructors/

        public ActionResult Index()
        {
            return View(JDB.BI.Content.ContentManager.GetInstructors());
        }

        public ActionResult Instructor(int ID)
        {
            return View(JDB.BI.Content.ContentManager.GetInstructor(ID));
        }

    }
}

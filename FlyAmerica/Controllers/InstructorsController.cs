using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flyamerica.Controllers
{
    public class InstructorsController : flyamerica.Controllers.BaseController
    {
        //
        // GET: /Instructors/

        public ActionResult Index()
        {
            BI.Content.ContentManager cm = new BI.Content.ContentManager();
            return View(cm.GetInstructors());
        }

        public ActionResult Instructor(int ID)
        {
            BI.Content.ContentManager cm = new BI.Content.ContentManager();
            return View(cm.GetInstructor(ID));
        }

    }
}

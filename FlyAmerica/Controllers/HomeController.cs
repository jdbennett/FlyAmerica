using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JDB;

namespace FlyAmerica.Controllers
{
    public class HomeController : FlyAmerica.Controllers.BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            return View(JDB.BI.Content.ContentManager.GetHomePage());
        }


        public ActionResult LoadMainContent()
        {
            return PartialView("Partials/_MainContent", JDB.BI.Content.ContentManager.GetMainContent());

        }
    }
}

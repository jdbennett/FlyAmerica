using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyAmerica.Controllers
{
    public class RecentNewsController : BaseController
    {
        //
        // GET: /RecentNews/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsStory(int ID)
        {
            return View();
        }

    }
}

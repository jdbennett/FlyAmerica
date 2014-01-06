using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyAmerica.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult GetTopNav()
        {
            return PartialView("Partials/_TopNav", JDB.BI.Navigation.NavigationManager.GetTopNavItems());
        }

    }


}

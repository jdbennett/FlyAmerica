using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flyamerica.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult GetTopNav()
        {
            BI.Navigation.NavigationManager nm = new BI.Navigation.NavigationManager();
            List<BI.ViewModels.NavItem> model = nm.GetTopNavItems();
            return PartialView("Partials/_TopNav", model);
        }

    }


}

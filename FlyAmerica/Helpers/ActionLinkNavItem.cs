using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;
using JDB;

namespace FlyAmerica.Helpers
{
    public static class ActionLinkNavItem
    {
        public static MvcHtmlString NavItem(this HtmlHelper htmlHelper, JDB.BI.ViewModels.NavItem navItem, RouteValueDictionary routeValues, bool resolveControllerNameOnly = true)
        {
            IDictionary<string, object> attrs = new Dictionary<string, object>();

                string controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller").ToLower();
                string action = htmlHelper.ViewContext.RouteData.GetRequiredString("action").ToLower();

                if (resolveControllerNameOnly ? controller == navItem.Controller.ToLower() : controller == navItem.Controller.ToLower() && action == navItem.Action.ToLower())
                    attrs.Add("class", "current");

            return htmlHelper.ActionLink(navItem.Text, navItem.Action, navItem.Controller, routeValues, attrs);
        }

        public static MvcHtmlString LiSelector(this HtmlHelper htmlHelper, JDB.BI.ViewModels.NavItem navItem)
        {
            IDictionary<string, object> attrs = new Dictionary<string, object>();
            string controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller").ToLower();

            if (navItem.Controller.ToLower() == controller)
                return new MvcHtmlString("current");

            else return new MvcHtmlString(string.Empty);

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace flyamerica.Helpers
{
    public static class ActionLinkNavItem
    {
        public static MvcHtmlString NavItem(this HtmlHelper htmlHelper, BI.ViewModels.NavItem navItem, RouteValueDictionary routeValues, bool resolveControllerNameOnly = true)
        {
            IDictionary<string, object> attrs = new Dictionary<string, object>();

                string controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller").ToLower();
                string action = htmlHelper.ViewContext.RouteData.GetRequiredString("action").ToLower();

                if (resolveControllerNameOnly ? controller == navItem.Controller.ToLower() : controller == navItem.Controller.ToLower() && action == navItem.Action.ToLower())
                    attrs.Add("class", "current");

            return htmlHelper.ActionLink(navItem.Text, navItem.Action, navItem.Controller, routeValues, attrs);
        }
    }
}
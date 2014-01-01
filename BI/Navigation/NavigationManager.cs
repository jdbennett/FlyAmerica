using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.Navigation
{
    public class NavigationManager
    {
        

        public List<BI.ViewModels.NavItem> GetTopNavItems()
        {
            List<BI.ViewModels.NavItem> items = new List<ViewModels.NavItem>();
            items.Add(new ViewModels.NavItem
            {
                Text = "Home",
                Controller = "Home",
                Action = "Index"
            });

            items.Add(new ViewModels.NavItem
            {
                Text = "Flight Training",
                Controller = "FlightTraining",
                Action = "Index"
            });

            items.Add(new ViewModels.NavItem
            {
                Text = "Instructors",
                Controller = "Instructors",
                Action = "Index"
            });

            items.Add(new ViewModels.NavItem
            {
                Text = "Aircraft",
                Controller = "Aircraft",
                Action = "Index"
            });

            items.Add(new ViewModels.NavItem
            {
                Text = "Maintenance",
                Controller = "Maintenance",
                Action = "Index"
            });

            List<BI.ViewModels.NavItem> subs = new List<ViewModels.NavItem>();
            subs.Add(new ViewModels.NavItem { Text = "News", Controller = "About", Action = "News" });
            subs.Add(new ViewModels.NavItem { Text = "Contact Us", Controller = "About", Action = "Contact" });

            items.Add(new ViewModels.NavItem
            {
                Text = "About",
                Controller = "About",
                Action = "Index",
                SubItems = subs

            });

            return items;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.ViewModels
{
    public class NavItem
    {
        public NavItem()
        {
            SubItems = new List<NavItem>();

        }
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public List<NavItem> SubItems { get; set; }
    }
}

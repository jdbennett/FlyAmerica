using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class RecentNewsItems
    {
        public RecentNewsItems()
        {
            NewsItems = new List<RecentNewsItem>();
        }
        public bool ShowItems { get; set; }
        public List<BI.ViewModels.RecentNewsItem> NewsItems { get; set; }
    }
}

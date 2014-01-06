using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class MainContent
    {
        public MainContent()
        {
            Items = new List<MainContentItem>();
        }
        public int Scroll { get; set; }
        public bool Paginate { get; set; }
        public bool Mousewheel { get; set; }
        public int ItemVisibleMin { get; set; }
        public int ItemVisibleMax { get; set; }
        public List<BI.ViewModels.MainContentItem> Items { get; set; }
    }
}

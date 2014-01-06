using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class RecentNewsItem
    {
        public RecentNewsItem()
        {
            Paragraphs = new List<ParagraphSection>();          
        }
        public int NewsItemId { get; set; }
        public DateTime NewsDate { get; set; }
        public string Headline { get; set; }
        public string Teaser { get; set; }
        public List<BI.ViewModels.ParagraphSection> Paragraphs { get; set; }
    }
}

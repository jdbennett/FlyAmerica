using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class FlightTraining
    {
        public FlightTraining()
        {
            Paragraphs = new List<BI.ViewModels.ParagraphSection>();
        }
        public string Image { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public List<BI.ViewModels.ParagraphSection> Paragraphs { get; set; }
    }
}

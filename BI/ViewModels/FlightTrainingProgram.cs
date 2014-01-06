using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class FlightTrainingProgram
    {
        public FlightTrainingProgram()
        {
            Descriptions = new List<ParagraphSection>();
            HighlightPoints = new List<string>();
        }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ShortDescription { get; set; }
        public List<BI.ViewModels.ParagraphSection> Descriptions { get; set; }
        public List<string> HighlightPoints {get;set;}
        public string Image { get; set; }
        public int Sequence { get; set; }

    }
}

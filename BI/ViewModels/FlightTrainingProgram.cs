using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.ViewModels
{
    public class FlightTrainingProgram
    {
        public FlightTrainingProgram()
        {
            Descriptions = new List<string>();
            HighlightPoints = new List<string>();
        }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ShortDescription { get; set; }
        public List<string> Descriptions { get; set; }
        public List<string> HighlightPoints {get;set;}
        public string Image { get; set; }
        public int Sequence { get; set; }

    }
}

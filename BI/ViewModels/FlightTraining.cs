using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.ViewModels
{
    public class FlightTraining
    {
        public FlightTraining()
        {
            Descriptions = new List<string>();
        }
        public string Image { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public List<string> Descriptions { get; set; }
    }
}

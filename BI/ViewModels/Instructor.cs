using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.ViewModels
{
    public class Instructor
    {
        public Instructor()
        {
            Ratings = new List<DAL.Reference.InstructorRatingTypes>();
        }
        public int InstructorID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public List<string> Descriptions { get; set; }
        public List<DAL.Reference.InstructorRatingTypes> Ratings { get; set; }
        public string Image { get; set; }

    }
}

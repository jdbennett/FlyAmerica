using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flyamerica.BI.Content
{
    public class ContentManager
    {
        public List<BI.ViewModels.SliderImage> GetHomePageSliderImages()
        {
            List<BI.ViewModels.SliderImage> images = new List<ViewModels.SliderImage>();
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide1.jpg", AltText = "BF Jet" });
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide2.jpg", AltText = "Another BF Jet" });
            images.Add(new ViewModels.SliderImage { URL = "Content/images/slide3.jpg", AltText = "Yet another BF jet" });

            return images;
        }

        public List<BI.ViewModels.FeaturedContent> GetFeaturedContent()
        {
            List<BI.ViewModels.FeaturedContent> content = new List<ViewModels.FeaturedContent>();
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon1.png", Title = "Flight Training", Description = "Some Words", Controller = "FlightTraining", Action = "Index" });
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon2.png", Title = "Aircraft Fleet", Description = "Some Words", Controller = "AircraftFleet", Action = "Index" });
            content.Add(new ViewModels.FeaturedContent { Image = "Content/images/page1_icon3.png", Title = "Aircraft Maintenance", Description = "Some Words", Controller = "AircraftMaintenance", Action = "Index" });
            return content;

        }

        public List<BI.ViewModels.FlightTrainingProgram> GetFlightTrainingPrograms()
        {
            List<BI.ViewModels.FlightTrainingProgram> programs = new List<ViewModels.FlightTrainingProgram>();
            List<string> d = new List<string>();
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius");


            programs.Add(new ViewModels.FlightTrainingProgram
            {
                ProgramId = 1,
                ProgramName = "Private Pilot Certificate",
                ShortDescription = "The course includes both ground school and flight time. You will learn about the mechanics of flying, airport operations, federal regulations, and get all the instruction and knowledge required for you to obtain a private pilot license.",
                Image = "Content/images/privatepilot.jpg",
                Descriptions = d,
                Sequence = 1

            });

            programs.Add(new ViewModels.FlightTrainingProgram
            {
                ProgramId = 2,
                ProgramName = "Instrument Rating",
                ShortDescription = "Once you have obtained your private pilot license, the Instrument Rating course will enable you to fly thought the clouds and in low visibility conditions.",
                Image = "Content/images/IFR.jpg",
                Descriptions = d,
                Sequence = 2
            });

            programs.Add(new ViewModels.FlightTrainingProgram
            {
                ProgramId = 3,
                ProgramName = "Commerical Pilot Certificate",
                ShortDescription = "The commercial pilot certificate enables you to work for compensation as a pilot. The training provides a comprehensive understanding of aircraft systems, while improving and perfecting your flying skills.",
                Image = "Content/images/commercialpilot.jpg",
                Descriptions = d,
                Sequence = 3
            });

            programs.Add(new ViewModels.FlightTrainingProgram
            {
                ProgramId = 4,
                ProgramName = "Advanced Ratings",
                ShortDescription = "We also provide ground and flight training for advanced endorsements and certificates.",
                Image = "Content/images/advanced.jpg",
                Descriptions = d,
                Sequence = 4
            });

            return programs;
        }

        public BI.ViewModels.FlightTraining GetFlightTrainingInfo()
        {
            List<string> d = new List<string>();
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            return new BI.ViewModels.FlightTraining { Image = "", Title = "Flight Training", ShortDescription = "Get certified and endorsed quickly and efficiently; continue your interests in recreational flying, or pursue a highly regarded career in aviation.", Descriptions = d };
        }

        public BI.ViewModels.FlightTrainingProgram GetFlightTrainingProgram(int ID)
        {
            List<BI.ViewModels.FlightTrainingProgram> programs = this.GetFlightTrainingPrograms();
            return programs.Where(p => p.ProgramId == ID).FirstOrDefault();
        }

        public List<BI.ViewModels.Instructor> GetInstructors()
        {
            List<BI.ViewModels.Instructor> instructors = new List<ViewModels.Instructor>();
            List<DAL.Reference.InstructorRatingTypes> types = new List<DAL.Reference.InstructorRatingTypes>();
            types.Add(DAL.Reference.InstructorRatingTypes.CFI);
            types.Add(DAL.Reference.InstructorRatingTypes.CFII);
            types.Add(DAL.Reference.InstructorRatingTypes.CFIMEI);

            List<string> d = new List<string>();
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            d.Add("Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");


            instructors.Add(new ViewModels.Instructor
            {
               InstructorID = 1, 
               Name = "Dave Gillingham",
               ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
               Ratings = types,
               Descriptions = d    
            });

            instructors.Add(new ViewModels.Instructor
            {
                InstructorID = 2,
                Name = "Jeff Kohlert",
                ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
                Ratings = types,
                Descriptions = d
            });

            instructors.Add(new ViewModels.Instructor
            {
                InstructorID = 3,
                Name = "Max Tucker",
                ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
                Ratings = types,
                Descriptions = d
            });

            instructors.Add(new ViewModels.Instructor
            {
                InstructorID = 4,
                Name = "Colleen La Plaza",
                ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
                Ratings = types,
                Descriptions = d
            });

            instructors.Add(new ViewModels.Instructor
            {
                InstructorID = 5,
                Name = "Ron McElroy",
                ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
                Ratings = types,
                Descriptions = d
            });

            instructors.Add(new ViewModels.Instructor
            {
                InstructorID = 6,
                Name = "Jordan Miller",
                ShortDescription = "Jeff has over 30 years experience in aviation with more than 15,000 flight hours. He is also a graduate of Southern Illinois University.",
                Ratings = types,
                Descriptions = d
            });

            return instructors;
        }

        public BI.ViewModels.Instructor GetInstructor(int ID)
        {
            List<BI.ViewModels.Instructor> instructors = this.GetInstructors();
            return instructors.Where(i => i.InstructorID == ID).FirstOrDefault();

        }
    }
}

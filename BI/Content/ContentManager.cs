using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JDB.BI.Content
{
    public static class ContentManager
    {

        public static BI.ViewModels.HomePage GetHomePage()
        {
            DAL.flyamericaEntities ctx = new DAL.flyamericaEntities();
            string page = DAL.Settings.Application_Pages.Home.ToString();
            string component = DAL.Settings.Home_Page_Components.SliderPanel.ToString();
            BI.ViewModels.HomePage homePage = new ViewModels.HomePage();
            List<DAL.asset> images = new List<DAL.asset>();
            List<DAL.application_page_setting> settings = new List<DAL.application_page_setting>();
            List<DAL.application_page_component_setting> sliderSettings = new List<DAL.application_page_component_setting>();
            try
            {
                //try wrapped for db calls
                try
                {
                    settings = ctx.application_page_setting.Where(x => x.page == page).ToList();
                    sliderSettings = ctx.application_page_component_setting.Where(x => x.component == component && x.page == page).ToList();

                    images = ctx.assets.Join
                                                       (
                                                           ctx.component_image,
                                                           a => a.id,
                                                           ci => ci.asset,
                                                           (a, ci) => new { a = a, ci = ci }
                                                        )
                                                       .Where(x => x.ci.isActive == true && x.ci.page == page && x.ci.component == component)
                                                       .Select(z => z.a).ToList();
                }
                catch (Exception ex)
                {
                    BI.Content.Exceptions.GetHomePageException cmEx = new Exceptions.GetHomePageException("Error Retrieving Home Page data from the database.", ex);
                    logException(cmEx);
                    throw cmEx;
                }

                //try wrapped for processing db records
                try
                {
                    homePage.ShowSliderPanel = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Settings.ShowSliderPanel.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.ShowMainPanel = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Settings.ShowMainPanel.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.ShowAccessoryPanel = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Settings.ShowAccessoryPanel.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.ShowFeaturedPanel = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Settings.ShowFeaturedPanel.ToString()).Select(y => y.value).FirstOrDefault());


                    homePage.HomePageSlider.HasThumbnails = Convert.ToBoolean(sliderSettings.Where(x => x.setting == DAL.Settings.Home_Page_Slider_Settings.HasThumbnails.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.HomePageSlider.Paginate = Convert.ToBoolean(sliderSettings.Where(x => x.setting == DAL.Settings.Home_Page_Slider_Settings.Paginate.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.HomePageSlider.ShowLoader = Convert.ToBoolean(sliderSettings.Where(x => x.setting == DAL.Settings.Home_Page_Slider_Settings.ShowLoader.ToString()).Select(y => y.value).FirstOrDefault());
                    homePage.HomePageSlider.ShowCaption = Convert.ToBoolean(sliderSettings.Where(x => x.setting == DAL.Settings.Home_Page_Slider_Settings.ShowCaption.ToString()).Select(y => y.value).FirstOrDefault());

                    foreach (DAL.asset img in images)
                    {
                        homePage.HomePageSlider.Images.Add(new ViewModels.SliderImage
                        {
                            Image = img.asset_name,
                            AltText = img.description
                        });
                    }
                }
                catch (Exception ex)
                {
                    BI.Content.Exceptions.GetHomePageException cmEx = new Exceptions.GetHomePageException("Error parsing homepage data to the model.", ex);
                    logException(cmEx);
                    throw cmEx;
                }
                             

                return homePage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ctx.Dispose();
            }             
            
        }


        public static BI.ViewModels.MainContent GetMainContent()
        {
            BI.ViewModels.MainContent content = new ViewModels.MainContent();
            DAL.flyamericaEntities ctx = new DAL.flyamericaEntities();
            string page = DAL.Settings.Application_Pages.Home.ToString();
            string component = DAL.Settings.Home_Page_Components.MainPanel.ToString();
            List<DAL.application_page_component_setting> settings = new List<DAL.application_page_component_setting>();


            try
            {

                    settings = ctx.application_page_component_setting.Where(x => x.component == component && x.page == page).ToList();
                    var contentItems = ctx.main_content_item.Where(mci => mci.active == true)
                                                            .Join
                                                             (
                                                                  ctx.assets,
                                                                  mci => mci.asset,
                                                                  a => a.id,
                                                                  (mci, a) => new { maincontentitem = mci, asset = a }
                                                             )
                                                             .Join
                                                             (
                                                                ctx.application_page,
                                                                contentitem => new { page = contentitem.maincontentitem.page, controller = contentitem.maincontentitem.controller, action = contentitem.maincontentitem.action },
                                                                appPage => new { page = appPage.page_name, controller = appPage.page_controller, action = appPage.page_action },
                                                                (contentitem, appPage) => new { contentitem, appPage }
                                                             ).OrderBy(x => x.contentitem.maincontentitem.sequence).ToList();

                


                foreach (var item in contentItems)
                {
                    content.Items.Add(new ViewModels.MainContentItem
                    {
                        Image = item.contentitem.asset.asset_name,
                        Title = item.appPage.page_link_text,
                        Description = item.contentitem.maincontentitem.short_description,
                        Controller = item.appPage.page_controller,
                        Action = item.appPage.page_action
                    });
                }

                content.ItemVisibleMax = Convert.ToInt32(settings.Where(x => x.setting == DAL.Settings.Home_Page_Main_Panel_Settings.ItemVisibleMax.ToString()).Select(y => y.value).FirstOrDefault());
                content.ItemVisibleMin = Convert.ToInt32(settings.Where(x => x.setting == DAL.Settings.Home_Page_Main_Panel_Settings.ItemVisibleMin.ToString()).Select(y => y.value).FirstOrDefault());
                content.Mousewheel = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Main_Panel_Settings.Mousewheel.ToString()).Select(y => y.value).FirstOrDefault());
                content.Paginate = Convert.ToBoolean(settings.Where(x => x.setting == DAL.Settings.Home_Page_Main_Panel_Settings.Paginate.ToString()).Select(y => y.value).FirstOrDefault());
                content.Scroll = Convert.ToInt32(settings.Where(x => x.setting == DAL.Settings.Home_Page_Main_Panel_Settings.Scroll.ToString()).Select(y => y.value).FirstOrDefault());

                return content;
            }
            catch (Exception ex)
            {
                Exceptions.GetMainContentException cmEx = new Exceptions.GetMainContentException("Error retrieving main content", ex);
                logException(cmEx);
                throw cmEx;
                
            }
            finally
            {
                ctx.Dispose();

            }
            

        }

        public static List<BI.ViewModels.FlightTrainingProgram> GetFlightTrainingPrograms()
        {
            List<BI.ViewModels.FlightTrainingProgram> programs = new List<ViewModels.FlightTrainingProgram>();
            List<BI.ViewModels.ParagraphSection> d = new List<BI.ViewModels.ParagraphSection>();
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius" });
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius" , Image ="012345.jpg"});
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius" });
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius"});
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius" });
            d.Add(new BI.ViewModels.ParagraphSection { Paragraph = "Lorem ipsum dolor sit amet, consecteturadipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur elit, sed do eius", Image = "012345.jpg" });

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

        public static BI.ViewModels.FlightTraining GetFlightTrainingInfo()
        {
            List<DAL.application_page_setting> settings = new List<DAL.application_page_setting>();
            BI.ViewModels.FlightTraining flightTrainingPage = new ViewModels.FlightTraining();
            string page = DAL.Settings.Application_Pages.FlightTraining.ToString();
            DAL.flyamericaEntities ctx = new DAL.flyamericaEntities();
            int[] paragraphIds;
            char split = ',';

            try
            {
                settings = ctx.application_page_setting.Where(x => x.page == page).ToList();
                paragraphIds = settings.Where(x => x.setting == DAL.Settings.FlightTraining_Page_Settings.PageParagraphs.ToString())
                                        .Select(y => y.value).FirstOrDefault()
                                        .Split(split).Select(p => Convert.ToInt32(p)).ToArray();
                var paragraphs = ctx.content_paragraph.Where(cp => paragraphIds.Any(y => paragraphIds.Contains(cp.id)))
                                                      .GroupJoin
                                                        (
                                                           ctx.assets,
                                                           cp => cp.asset,
                                                           a => a.id,
                                                           (cp, r) => r
                                                               .Select(par => new { text = cp.text, img = par.asset_name })
                                                               .DefaultIfEmpty( new {text = cp.text, img = "" })
                                                        ).SelectMany(r => r).ToList();
                int image = Convert.ToInt32(settings.Where(x => x.setting == DAL.Settings.FlightTraining_Page_Settings.PageImage.ToString()).Select(y => y.value).FirstOrDefault());

                flightTrainingPage.Image = ctx.assets.Where(x => x.id == image).Select(y => y.asset_name).FirstOrDefault();
               
                flightTrainingPage.Title = settings.Where(x => x.setting == DAL.Settings.FlightTraining_Page_Settings.PageTitle.ToString()).Select(y => y.value).FirstOrDefault();
                flightTrainingPage.ShortDescription = settings.Where(x => x.setting == DAL.Settings.FlightTraining_Page_Settings.ShortDescription.ToString()).Select(y => y.value).FirstOrDefault();

                foreach (var item in paragraphs)
                {
                    flightTrainingPage.Paragraphs.Add(new ViewModels.ParagraphSection
                    {
                        Image = item.img,
                        Paragraph = item.text

                    });
                }

                return flightTrainingPage;

            }
            catch (Exception ex)
            {

                Exceptions.GetFlightTrainingException cmEX = new Exceptions.GetFlightTrainingException("Error retrieving Flight Training page info.", ex);
                logException(cmEX);
                throw cmEX;
            }
                        
        }

        public static BI.ViewModels.FlightTrainingProgram GetFlightTrainingProgram(int ID)
        {
            List<BI.ViewModels.FlightTrainingProgram> programs = GetFlightTrainingPrograms();
            return programs.Where(p => p.ProgramId == ID).FirstOrDefault();
        }

        public static  List<BI.ViewModels.Instructor> GetInstructors()
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

        public static BI.ViewModels.Instructor GetInstructor(int ID)
        {
            List<BI.ViewModels.Instructor> instructors = GetInstructors();
            return instructors.Where(i => i.InstructorID == ID).FirstOrDefault();

        }

        public static BI.ViewModels.RecentNewsItems GetNewsItems(DAL.Reference.NewsItemTypes types)
        {
            Thread.Sleep(10000);

            BI.ViewModels.RecentNewsItems ri = new ViewModels.RecentNewsItems();
            List<BI.ViewModels.RecentNewsItem> items = new List<ViewModels.RecentNewsItem>();
            items.Add(new ViewModels.RecentNewsItem
            {
                NewsItemId = 1,
                Headline = "New Solo Student",
                Teaser = "Patrick Manelly recently soloed in N33763.  Please contratulate Patrick on his new found love!",
                NewsDate = DateTime.Today

            });

            items.Add(new ViewModels.RecentNewsItem
            {
                NewsItemId = 2,
                Headline = "Checkride Complete",
                Teaser = "Please welcom Jeff Kohlert to the new Toastmaster International club!",
                NewsDate = new DateTime(2013,12,13)

            });

            items.Add(new ViewModels.RecentNewsItem
            {
                NewsItemId = 3,
                Headline = "10th Pilot Created",
                Teaser = "Fly America has successfully graduated their 10th Private Pilot.",
                NewsDate = new DateTime(2013, 9, 2)

            });

            items.Add(new ViewModels.RecentNewsItem
            {
                NewsItemId = 4,
                Headline = "Runway 20 Extension",
                Teaser = "20/02 will be extended on July 20th.  Please plan on using alternate Runways.",
                NewsDate = new DateTime(2013, 4, 21)

            });

            ri.ShowItems = true;
            ri.NewsItems = items;

            return ri;

        }

        public static List<BI.ViewModels.Testimonial> GetTestimonials()
        {
            Thread.Sleep(5000);
            List<BI.ViewModels.Testimonial> items = new List<ViewModels.Testimonial>();

            items.Add(new ViewModels.Testimonial { Quote = "This is the best fucking thing I have ever seen!", Author = "John Bennett" });
            items.Add(new ViewModels.Testimonial { Quote = "Amazing!", Author = "Jeff Kohlert" });
            items.Add(new ViewModels.Testimonial { Quote = "Blah...Unreal....Blah!", Author = "Dave Gillingham" });

            return items;

        }


        private static void logException(Exception ex)
        {
            Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));
        }
    }
}

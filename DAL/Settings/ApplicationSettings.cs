using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.DAL.Settings
{
    public enum Application_Pages
    {
        Home,
        FlightTraining,
        Aircraft,
        Maintenance,
        RecentNews,
        Instructors

    }

    public enum Home_Page_Settings
    {
        ShowAccessoryPanel,
        ShowFeaturedPanel,
        ShowMainPanel,
        ShowSliderPanel
    }

    public enum Home_Page_Components
    {
        AccessoryPanel,
        FeaturedPanel,
        MainPanel,
        SliderPanel
    }

    public enum Home_Page_Slider_Settings
    {
        HasThumbnails,
        Paginate,
        ShowCaption,
        ShowLoader
    }

    public enum Home_Page_Main_Panel_Settings
    {
        Scroll,
        Paginate,
        Mousewheel,
        ItemVisibleMin,
        ItemVisibleMax
    }

    public enum FlightTraining_Page_Settings
    {
        PageImage,
        PageParagraphs,
        PageTitle,
        ShortDescription
    }
}

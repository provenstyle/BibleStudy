namespace BibleStudy.Console.Features.Home
{
    using System.Diagnostics;
    using System.Reflection;
    using Miruken.Mvc;

    public class HomeController : Controller
    {
        public string Version { get; set; } = "Unknown";

        public HomeController()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            if (location != null )
            {
                Version = FileVersionInfo.GetVersionInfo(location).FileVersion;
            }
        }

        public void ShowHomeView()
        {
            Show<HomeView>();
        }

        public void ShowViewOne()
        {
            Show<OneView>();
        }

        public void GoToViewTwo()
        {
            Push<TwoController>().ShowTwo();
        }
    }
}

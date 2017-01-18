namespace BibleStudy.Console.Features.About
{
    using System.Diagnostics;
    using System.Reflection;
    using Infrastructure;

    public class AboutController : BaseController
    {
        public string Version { get; set; } = "unknown";

        public AboutController()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            if (location != null )
            {
                Version = FileVersionInfo.GetVersionInfo(location).FileVersion;
            }
        }
        
        public void ShowAbout()
        {
            Show<AboutView>();
        }
    }
}

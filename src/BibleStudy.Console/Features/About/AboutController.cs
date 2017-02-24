namespace BibleStudy.Console.Features.About
{
    using System.Diagnostics;
    using System.Reflection;
    using Infrastructure;
    using Miruken.Concurrency;

    public class AboutController : FeatureController
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

        public Promise ShowAbout()
        {
            Show<AboutView>();
            return Promise.Empty;
        }
    }
}

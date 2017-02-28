namespace BibleStudy.Console.Infrastructure
{
    using Miruken.Concurrency;
    using Miruken.Mvc;

    public abstract class FeatureController : Controller
    {
        public Promise Quit()
        {
            Program.Quit();
            return Promise.Empty;
        }

        public Promise Back()
        {
            EndContext();
            return Promise.Empty;
        }
    }
}
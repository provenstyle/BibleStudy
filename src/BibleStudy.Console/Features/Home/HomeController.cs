namespace BibleStudy.Console.Features.Home
{
    using Infrastructure;
    using Miruken.Concurrency;
    using Verses;

    public class HomeController : FeatureController
    {
        public void ShowHome()
        {
            Show<HomeView>();
        }

        public Promise GoToVerses()
        {
            return Push<VersesController>().ShowVerses();
        }
    }
}

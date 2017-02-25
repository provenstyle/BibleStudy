namespace BibleStudy.Console.Features.Home
{
    using Infrastructure;

    public class HomeController : FeatureController
    {
        public void ShowHome()
        {
            Show<HomeView>();
        }
    }
}

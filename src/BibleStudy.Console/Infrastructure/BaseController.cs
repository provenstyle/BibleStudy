namespace BibleStudy.Console.Infrastructure
{
    using Features.About;
    using Features.Books;
    using Miruken.Concurrency;
    using Miruken.Context;
    using Miruken.Mvc;

    public abstract class FeatureController : Controller
    {
        public IContext Body;

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

        public Promise GoToAbout()
        {
            return Next<AboutController>(Body).ShowAbout();
        }

        public Promise GoToBooks()
        {
            return Next<BooksController>(Body).ShowBooks();
        }
    }
}
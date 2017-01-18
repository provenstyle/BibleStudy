namespace BibleStudy.Console.Features.Home
{
    using System.Threading.Tasks;
    using About;
    using Books;
    using Infrastructure;
    using Verses;

    public class HomeController : BaseController
    {
        public void ShowHome()
        {
            Show<HomeView>();
        }

        public void GoToVerses()
        {
            Push<VersesController>().ShowVerses();
        }

        public async Task GoToBooks()
        {
            await Push<ListBooksController>().ShowBooks();
        }

        public void GoToAbout()
        {
            Push<AboutController>().ShowAbout();
        }
    }
}

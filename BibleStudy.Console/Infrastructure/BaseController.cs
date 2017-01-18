namespace BibleStudy.Console.Infrastructure
{
    using Miruken.Mvc;

    public abstract class BaseController : Controller
    {
        public void Quit()
        {
            Program.Quit();
        }

        public void Back()
        {
            EndContext();
        }
    }
}
namespace ConsoleTestApp.Features.A
{
    using B;
    using Miruken.Mvc;

    public class AController : Controller
    {
        public void ShowAView()
        {
            Show<AView>();
        }

        public void GoToBView()
        {
            Push<BController>().ShowBView();
        }

        public void Quit()
        {
            Program.Quit = true;
        }
    }
}

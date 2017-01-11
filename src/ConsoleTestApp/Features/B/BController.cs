namespace ConsoleTestApp.Features.B
{
    using C;
    using Miruken.Mvc;

    public class BController : Controller
    {
        public void ShowBView()
        {
            Show<BView>();
        }

        public void GoToCView()
        {
            Push<CController>().ShowCView();
        }

        public void Back()
        {
            EndContext();
        }
    }
}
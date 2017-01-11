namespace ConsoleTestApp.Features.C
{
    using Miruken.Mvc;

    public class CController : Controller
    {
        public void ShowCView()
        {
            Show<CView>();
        }

        public void Back()
        {
            EndContext();
        }
    }
}
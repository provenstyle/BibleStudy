namespace BibleStudy.Console.Features.Home
{
    using Miruken.Mvc;

    public class ThreeController : Controller
    {
        public void ShowThree()
        {
            Show<ThreeView>();
        }

        public void Back()
        {
            EndContext();
        }
    }
}
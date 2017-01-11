namespace BibleStudy.Console.Features.Home
{
    using Miruken.Mvc;

    public class TwoController : Controller
    {
        public void ShowTwo()
        {
            Show<TwoView>();
        }

        public void GoToViewThree()
        {
            Push<ThreeController>().ShowThree();
        }

        public void Back()
        {
            EndContext();
        }
    }
}
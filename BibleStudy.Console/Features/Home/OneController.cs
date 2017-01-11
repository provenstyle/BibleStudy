namespace BibleStudy.Console.Features.Home
{
    using Miruken.Mvc;

    public class OneController : Controller
    {
        public void ShowViewOne()
        {
            Show<OneView>();
        }

        public void GoToViewTwo()
        {
            Push<TwoController>().ShowTwo();
        }
    }
}

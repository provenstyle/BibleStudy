namespace BibleStudy.Console.Features.Layout
{
    using Header;
    using Home;
    using Miruken.Mvc;

    public class LayoutController : Controller
    {
        public void ShowLayout()
        {
            Show<LayoutView>(v =>
             {
                 var header = AddRegion(v.Header);
                 var body   = AddRegion(v.Body);
                 Next<HeaderController>(header).ShowHeader(body);
                 Next<HomeController>(body).ShowHome();
             });
        }
    }
}
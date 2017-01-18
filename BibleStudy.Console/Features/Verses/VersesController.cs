namespace BibleStudy.Console.Features.Verses
{
    using Infrastructure;

    public class VersesController : BaseController
    {
        public void ShowVerses()
        {
            Show<VersesView>();
        }
    }
}

namespace BibleStudy.Console.Features.Verses
{
    using Infrastructure;
    using Miruken.Concurrency;

    public class VersesController : FeatureController
    {
        public Promise ShowVerses()
        {
            Show<VersesView>();
            return Promise.Empty;
        }
    }
}

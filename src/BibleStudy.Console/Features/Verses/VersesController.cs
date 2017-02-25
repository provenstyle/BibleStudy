namespace BibleStudy.Console.Features.Verses
{
    using System.Linq;
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Concurrency;
    using ServiceBus;

    public class VersesController : FeatureController
    {
        public VerseData[] Verses { get; set; }

        public Promise ShowVerses()
        {
            return P<IServiceBus>().Process(new GetVerses()).Then((result, synchronous) =>
            {
                Verses = result.Verses
                    .OrderBy(x => x.BookId)
                    .ThenBy(x => x.Chapter)
                    .ThenBy(x => x.Number)
                    .ToArray();

                Show<VersesView>();
            });
        }

        public Promise GoToCreateVerse()
        {
            return Next<CreateVerseController>(IO).ShowCreateVerse();
        }

        public Promise GoToVerse(VerseData verse)
        {
            return Next<VerseController>(IO).ShowVerse(verse);
        }
    }
}

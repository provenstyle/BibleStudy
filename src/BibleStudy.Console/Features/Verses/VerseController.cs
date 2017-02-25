namespace BibleStudy.Console.Features.Verses
{
    using System.Linq;
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Callback;
    using Miruken.Concurrency;
    using ServiceBus;
    using Study;

    public class VerseController : FeatureController
    {

        public VerseData Verse { get; set; }

        public Promise ShowVerse(VerseData verse)
        {
            return P<IServiceBus>(IO).Process(new GetVerses() {Ids = new[] {verse.Id}}).Then((result, synchronous) =>
            {
                Verse = result.Verses.FirstOrDefault();
                Show<VerseView>();
            });
        }

        [Provides]
        public VerseData ProvidesVerse()
        {
            return Verse;
        }

        public Promise GoToStudy()
        {
            Next<StudyController>(IO).ShowStudy();
            return Promise.Empty;
        }

        public Promise GoToUpdateVerse()
        {
            return Promise.Empty;
        }
    }
}

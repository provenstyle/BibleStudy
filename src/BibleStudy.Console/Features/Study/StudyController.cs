namespace BibleStudy.Console.Features.Study
{
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Callback;
    using Miruken.Concurrency;

    public class StudyController : FeatureController
    {
        public VerseData Verse { get; set; }

        public StudyController()
        {
            Verse = IO.Resolve<VerseData>();
        }

        public Promise ShowStudy()
        {
            Show<StudyView>();
            return Promise.Empty;
        }

        public Promise Observation()
        {
            return Promise.Empty;
        }
    }
}

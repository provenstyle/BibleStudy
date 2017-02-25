namespace BibleStudy.Console.Features.Verses
{
    using Data.Api.Books;
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Concurrency;
    using Miruken.Error;
    using ServiceBus;

    public class CreateVerseController : FeatureController
    {
        private readonly IConfig _config;
        public VerseData Verse  { get; set; } = new VerseData();
        public BookData[] Books { get; set; }

        public CreateVerseController(IConfig config)
        {
            _config = config;
        }

        public Promise ShowCreateVerse()
        {
            return P<IServiceBus>(IO.Recover()).Process(new GetBooks()).Then((result, synchronous) =>
            {
                CreateVerseView view = null;
                Books = result?.Books;
                Show<CreateVerseView>(x => view = x);
                view.FillOutForm();
                return CreateVerse();
            });
        }

        public Promise CreateVerse()
        {
            Verse.CreatedBy  = _config.UserName;
            Verse.ModifiedBy = _config.UserName;
            return P<IServiceBus>(IO).Process(new CreateVerse(Verse))
                .Then((result, synchronous) => Next<VersesController>(IO).ShowVerses());
        }
    }
}

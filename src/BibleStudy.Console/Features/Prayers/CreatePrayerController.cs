namespace BibleStudy.Console.Features.Prayers
{
    using System.Collections.Generic;
    using Data.Api.Prayers;
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Callback;
    using Miruken.Concurrency;
    using Miruken.Error;
    using Observations;
    using ServiceBus;

    public class CreatePrayerController : FeatureController
    {
        private readonly IConfig _config;

        public PrayerData Prayer { get; set; } = new PrayerData();

        public CreatePrayerController(IConfig config)
        {
            _config = config;
        }

        public Promise ShowCreatePrayer()
        {
            var verse = IO.Resolve<VerseData>();
            Prayer.Verses = new List<VerseData> { verse };

            CreatePrayerView view = null;
            Show<CreatePrayerView>(x => view = x);

            view.CompleteForm();

            Prayer.CreatedBy  = _config.UserName;
            Prayer.ModifiedBy = _config.UserName;
            return P<IServiceBus>(IO.Recover()).Process(new CreatePrayer(Prayer))
                .Then((result, synchronous) => Back());
        }
    }
}

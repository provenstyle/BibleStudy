namespace BibleStudy.Console.Features.Observations
{
    using System.Collections.Generic;
    using Data.Api.Observations;
    using Data.Api.Verses;
    using Infrastructure;
    using Miruken.Callback;
    using Miruken.Concurrency;
    using Miruken.Error;
    using ServiceBus;

    public class CreateObservationController : FeatureController
    {
        private readonly IConfig _config;

        public ObservationData Observation { get; set; } = new ObservationData();

        public CreateObservationController(IConfig config)
        {
            _config = config;
        }

        public Promise ShowCreateObservation()
        {
            var verse = IO.Resolve<VerseData>();
            Observation.Verses = new List<VerseData> {verse};

            CreateObservationView view = null;
            Show<CreateObservationView>(x => view = x);

            view.CompleteForm();

            Observation.CreatedBy  = _config.UserName;
            Observation.ModifiedBy = _config.UserName;
            return P<IServiceBus>(IO.Recover()).Process(new CreateObservation(Observation))
                .Then((result, synchronous) => Back());
        }
    }
}

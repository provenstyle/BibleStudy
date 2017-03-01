namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Highway.Data.Repositories;
    using MediatR;
    using Observations;
    using Queries;
    using Entities;
    using Highway.Data;

    public class ObservationAggregateHandler :
        IAsyncRequestHandler<CreateObservation, ObservationData>,
        IAsyncRequestHandler<GetObservations, ObservationResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;
        private readonly DateTime _now;

        public ObservationAggregateHandler(IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
            _now = DateTime.Now;
        }

        public async Task<ObservationData> Handle(CreateObservation message)
        {
            var observation = await Map(new Observation(), message.Resource);
            observation.Created = _now;

            //is this really how I want to handle foreign key tables
            foreach (var item in observation.VerseObservations)
            {
                item.Created    = _now;
                item.CreatedBy  = message.Resource.CreatedBy;
                item.Modified   = _now;
                item.ModifiedBy = message.Resource.ModifiedBy;
            }

            _repository.Context.Add(observation);

            await _repository.Context.CommitAsync();

            return new ObservationData
            {
                Id = observation.Id,
                RowVersion = observation.RowVersion
            };
        }

        private class GetVerses : Query<Verse>
        {
            public GetVerses(int[] ids)
            {
                ContextQuery = c =>
                   {
                       return c.AsQueryable<Verse>()
                           .Where(x => ids.Contains(x.Id));
                   };
            }
        }

        public async Task<ObservationResult> Handle(GetObservations message)
        {
            var observations = (await _repository.FindAsync(new GetObservationsById(message.Ids)))
                .ToArray();

            return new ObservationResult
            {
                Observations = observations
            };
        }

        public async Task<Observation> Map(Observation observation, ObservationData data)
        {
            var ids = data.Verses.Select(x => x.Id).ToArray();
            var verses = (await _repository.FindAsync(new GetVerses(ids))).ToArray();
            foreach (var verse in verses)
                observation.AddVerse(verse);

            if (data.Text != null)
                observation.Text = data.Text;

            if (data.CreatedBy != null)
                observation.CreatedBy = data.CreatedBy;

            if (data.ModifiedBy != null)
                observation.ModifiedBy = data.ModifiedBy;

            observation.Modified = _now;

            return observation;
        }

    }
}

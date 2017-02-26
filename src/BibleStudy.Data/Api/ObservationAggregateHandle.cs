namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Books;
    using Highway.Data.Repositories;
    using MediatR;
    using Observations;
    using Queries;
    using BibleStudy.Data.Entities;

    public class ObservationAggregateHandler :
        IAsyncRequestHandler<CreateObservation, ObservationData>,
        IAsyncRequestHandler<GetObservations, ObservationResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;
        private readonly DateTime _now;

        public ObservationAggregateHandler(IMediator mediator, IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
            _now = DateTime.Now;
        }

        public async Task<ObservationData> Handle(CreateObservation message)
        {
            var observation = Map(new Observation(), message.Resource);
            observation.Created = _now;

            _repository.Context.Add(observation);
            await _repository.Context.CommitAsync();

            return new ObservationData
            {
                Id = observation.Id,
                RowVersion = observation.RowVersion
            };
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

        public Observation Map(Observation observation, ObservationData data)
        {
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

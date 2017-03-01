namespace BibleStudy.Data.Api
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Entities;
    using Highway.Data;
    using Highway.Data.Repositories;
    using MediatR;
    using Prayers;
    using Queries;
    using Prayer = Entities.Prayer;

    public class PrayerAggregateHandler :
        IAsyncRequestHandler<CreatePrayer, PrayerData>,
        IAsyncRequestHandler<GetPrayers, PrayerResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;
        private readonly DateTime                            _now;

        public PrayerAggregateHandler(IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
            _now        = DateTime.Now;
        }

        public async Task<PrayerData> Handle(CreatePrayer message)
        {
            var prayerData = message.Resource;
            var prayer = Map(new Prayer(), prayerData);
            prayer.Created = _now;

            foreach (var item in prayer.VersePrayers)
            {
                item.Created    = _now;
                item.CreatedBy  = prayerData.CreatedBy;
                item.Modified   = _now;
                item.ModifiedBy = prayerData.ModifiedBy;
            }

            _repository.Context.Add(prayer);
            await _repository.Context.CommitAsync();

            return new PrayerData
            {
                Id = prayer.Id,
                RowVersion = prayer.RowVersion
            };
        }

        public async Task<PrayerResult> Handle(GetPrayers message)
        {
            var prayers = (await _repository.FindAsync(new GetPrayersById(message.Ids)))
                .ToArray();

            return new PrayerResult
            {
                Prayers = prayers
            };
        }

        public Prayer Map(Prayer prayer, PrayerData data)
        {
            var verses = data.Verses.Select(x => new Verse {Id = x.Id});
            foreach (var verse in verses)
            {
                prayer.AddVerse(verse);
                verse.AttachEntity((DbContext)_repository.DomainContext);
            }

            if (data.Text != null)
                prayer.Text = data.Text;

            if (data.CreatedBy != null)
                prayer.CreatedBy = data.CreatedBy;

            if (data.ModifiedBy != null)
                prayer.ModifiedBy = data.ModifiedBy;

            prayer.Modified = _now;

            return prayer;
        }
    }
}
namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Books;
    using Entities;
    using Highway.Data.Repositories;
    using MediatR;
    using Observations;
    using Prayers;
    using Queries;
    using Verses;

    public class VerseAggregateHandler :
        IAsyncRequestHandler<CreateVerse, VerseData>,
        IAsyncRequestHandler<GetVerses, VerseResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;
        private readonly DateTime                            _now;
        private readonly BookData[]                          _books;

        public VerseAggregateHandler(IMediator mediator, IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
            _now        = DateTime.Now;

            var task = mediator.SendAsync(new GetBooks());
            task.Wait();
            _books = task.Result.Books;
        }

        public async Task<VerseData> Handle(CreateVerse message)
        {
            var verse = Map(new Verse(), message.Resource);
            verse.Created = _now;

            _repository.Context.Add(verse);
            await _repository.Context.CommitAsync();

            return new VerseData
            {
                Id = verse.Id,
                RowVersion = verse.RowVersion
            };
        }

        public async Task<VerseResult> Handle(GetVerses message)
        {
            var verses = (await _repository.FindAsync(new GetVersesById(message.Ids)
            {
                IncludeObservations = message.IncludeObservations,
                IncludePrayers      = message.IncludePrayers
            }))
            .Select(x => Map(new VerseData(), x)).ToArray();

            foreach (var verse in verses)
                verse.Book = _books.FirstOrDefault(book => book.Id == verse.BookId);

            return new VerseResult
            {
                Verses = verses
            };
        }

        public Verse Map(Verse verse, VerseData data)
        {
            if (data.BookId.HasValue)
                verse.BookId = data.BookId.Value;

            if (data.Chapter.HasValue)
                verse.Chapter = data.Chapter.Value;

            if (data.Number.HasValue)
                verse.Number = data.Number.Value;

            if (data.Text != null)
                verse.Text = data.Text;

            if (data.CreatedBy != null)
                verse.CreatedBy = data.CreatedBy;

            if (data.ModifiedBy != null)
                verse.ModifiedBy = data.ModifiedBy;

            verse.Modified = _now;

            return verse;
        }

        public VerseData Map(VerseData data, Verse verse)
        {
            data.Id          = verse.Id;
            data.BookId      = verse.BookId;
            data.Chapter     = verse.Chapter;
            data.Number      = verse.Number;
            data.Text        = verse.Text;
            data.Created     = verse.Created;
            data.CreatedBy   = verse.CreatedBy;
            data.Modified    = verse.Modified;
            data.ModifiedBy  = verse.ModifiedBy;
            data.RowVersion  = verse.RowVersion;

            data.Observations = verse.VerseObservations
                .Select(x => Map(new ObservationData(), x))
                .ToArray();

            data.Prayers = verse.VersePrayers
                .Select(x => Map(new PrayerData(), x))
                .ToArray();

            return data;
        }

        public ObservationData Map(ObservationData data, VerseObservation verseObservation)
        {
            if (verseObservation.Observation == null) return null;

            var observation = verseObservation.Observation;

            data.Text = observation.Text;
            data.Id   = observation.Id;

            return data;
        }

        public PrayerData Map(PrayerData data, VersePrayer versePrayer)
        {
            if (versePrayer.Prayer == null) return null;

            var prayer = versePrayer.Prayer;

            data.Text = prayer.Text;
            data.Id   = prayer.Id;

            return data;
        }
    }
}

using BibleStudy.Data.Api.Verses;

namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Books;
    using Castle.Core.Internal;
    using Entities;
    using Highway.Data.Repositories;
    using MediatR;
    using Queries;

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
            var verses = (await _repository.FindAsync(new GetVersesById(message.Ids)))
                .ToArray();

            verses.ForEach(x => x.Book = _books.FirstOrDefault(book => book.Id == x.BookId));

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

    }
}

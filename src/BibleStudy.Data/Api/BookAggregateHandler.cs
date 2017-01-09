using BibleStudy.Data.Api.Verses;

namespace BibleStudy.Data.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Books;
    using Entities;
    using Highway.Data.Repositories;
    using MediatR;
    using Queries;

    public class BookAggregateHandler :
        IAsyncRequestHandler<GetBooks, BookResult>
    {
        private readonly IDomainRepository<BibleStudyDomain> _repository;

        public BookAggregateHandler(IDomainRepository<BibleStudyDomain> repository)
        {
            _repository = repository;
        }

        public async Task<BookResult> Handle(GetBooks message)
        {
            var data = (await _repository.FindAsync(new GetBooksById(message.Ids)))
                .Select(x => Map(new BookData(), x))
                .ToArray();

            return new BookResult
            {
                Books = data
            };
        }

        public BookData Map(BookData book, Book data)
        {
            book.Id = data.Id;
            book.Name = data.Name;
            book.Testament = data.TestamentId == 1
                ? TestamentData.OldTestament
                : TestamentData.NewTestament;

            return book;
        }
    }
}

namespace BibleStudy.Console.Features.Books
{
    using System.Threading.Tasks;
    using Data.Api.Books;
    using MediatR;
    using Miruken.Callback;

    public interface IBook
    {
        Task<BookData[]> GetBooks();
    }

    public class BookHandler : Handler, IBook
    {
        private readonly IMediator _mediator;

        public BookHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BookData[]> GetBooks()
        {
            return (await _mediator.SendAsync(new GetBooks())).Books;
        }
    }
}

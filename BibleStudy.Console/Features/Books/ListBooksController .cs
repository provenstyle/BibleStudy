namespace BibleStudy.Console.Features.Books
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Api.Books;
    using Infrastructure;
    using MediatR;

    public class ListBooksController : BaseController
    {
        private readonly IMediator _mediator;
        public BookData[] OldTestament { get; set; }
        public BookData[] NewTestament { get; set; }

        public ListBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ShowBooks()
        {
            var books = (await _mediator.SendAsync(new GetBooks())).Books;
            OldTestament = books.Where(x => x.Testament.Id == 1).ToArray();
            NewTestament = books.Where(x => x.Testament.Id == 2).ToArray();

            Show<ListBooksView>();
        }
    }
}

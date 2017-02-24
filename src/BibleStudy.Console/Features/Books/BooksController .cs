namespace BibleStudy.Console.Features.Books
{
    using System.Linq;
    using Data.Api.Books;
    using Infrastructure;
    using Miruken.Concurrency;
    using ServiceBus;

    public class BooksController : FeatureController
    {
        public BookData[] OldTestament { get; set; }
        public BookData[] NewTestament { get; set; }

        public Promise ShowBooks()
        {
            return P<IServiceBus>().Process(new GetBooks()).Then((result, synchronous) =>
            {
                var books = result.Books;
                OldTestament = books?.Where(x => x.Testament.Id == 1).ToArray();
                NewTestament = books?.Where(x => x.Testament.Id == 2).ToArray();
                Show<BooksView>();
            });
        }
    }
}

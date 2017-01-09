namespace BibleStudy.Console.Commands
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Api.Books;
    using Infrastructure;
    using MediatR;

    public class GetBooksCommand : BaseCommand
    {
        public GetBooksCommand(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanHandle(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "get" &&
                   args[1] == "books";
        }

        protected override async Task InternalHandle(string[] args)
        {
            Header("Books");

            var books = (await Mediator.SendAsync(new GetBooks())).Books;
            var oldTestament = books.Where(x => x.Testament.Id == 1).ToArray();
            var newTestament = books.Where(x => x.Testament.Id == 2).ToArray();
            var layout = new ColumnLayout(2);

            foreach (var book in oldTestament)
            {
                layout.Add(0, $"{book.Id:00} - {book.Name}");
            }

            foreach (var book in newTestament)
            {
                layout.Add(1, $"{book.Id:00} - {book.Name}");
            }

            Console.WriteLine(layout);

            Footer();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "get books",
            Description = "List all books"
        };

    }
}

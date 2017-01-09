namespace BibleStudy.Console.Commands
{
    using System;
    using System.Threading.Tasks;
    using Data.Api.Verses;
    using Infrastructure;
    using MediatR;

    public class GetVerseCommand : BaseCommand
    {
        private readonly IMediator _mediator;

        public GetVerseCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override bool InternalCanProcess(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "get" &&
                   args[1] == "verses";
        }

        protected override async Task InternalProcess(string[] args)
        {
            Header("Verses");
            var verses = (await _mediator.SendAsync(new GetVerses())).Verses;
            foreach (var verse in verses)
            {
                Console.WriteLine($"{verse.BookId} {verse.Chapter}:{verse.Number}");
                Console.WriteLine(verse.Text);
                Console.WriteLine();
            }
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "get verses",
            Description = "List all verses"
        };
    }
}

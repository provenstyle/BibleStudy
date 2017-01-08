using System.Threading.Tasks;
using BibleStudy.Data.Api.Verses;

namespace BibleStudy.Console.Commands
{
    using System;
    using Infrastructure;
    using MediatR;

    public class GetVerseCommand : BaseCommand
    {
        private readonly IMediator _mediator;

        public GetVerseCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override bool InternalCanProcess(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "get" &&
                   args[1] == "verse";
        }

        public override async Task InternalProcess(string[] args)
        {
            var verses = (await _mediator.SendAsync(new GetVerses())).Verses;
            System.Console.WriteLine("Verses");
            foreach (var verse in verses)
            {
                Console.WriteLine($"{verse.BookId} {verse.Chapter}:{verse.Number}");
                Console.WriteLine(verse.Text);
                Console.WriteLine();
            }
        }
    }
}

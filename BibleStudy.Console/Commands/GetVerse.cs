namespace BibleStudy.Console.Commands
{
    using System;
    using System.Threading.Tasks;
    using Data.Api.Verses;
    using Infrastructure;
    using MediatR;

    public class GetVerseCommand : BaseCommand
    {

        public GetVerseCommand(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanHandle(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "get" &&
                   args[1] == "verses";
        }

        protected override async Task InternalHandle(string[] args)
        {
            Header("Verses");
            var verses = (await Mediator.SendAsync(new GetVerses())).Verses;
            foreach (var verse in verses)
            {
                Console.WriteLine(verse);
                Console.WriteLine();
            }
            Footer();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "get verses",
            Description = "List all verses"
        };
    }
}

namespace BibleStudy.Console.Commands
{
    using System;
    using System.Threading.Tasks;
    using Data.Api.Verses;
    using Infrastructure;
    using MediatR;

    public class CreateVerseCommand : BaseCommand
    {
        private readonly IConfig   _config;

        public CreateVerseCommand(IMediator mediator, IConfig config)
            : base(mediator)
        {
            _config   = config;
        }

        protected override bool InternalCanProcess(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "create" &&
                   args[1] == "verse";
        }

        protected override async Task InternalProcess(string[] args)
        {
            do
            {
                Header("Create Verse");

                var book = (await PromptForBook());

                var verseData = new VerseData
                {
                    Book       = book,
                    BookId     = book.Id,
                    Chapter    = PromptForInt("Chapter:"),
                    Number     = PromptForInt("Verse:"),
                    Text       = PromptForString("Text:"),
                    CreatedBy  = _config.UserName,
                    ModifiedBy = _config.UserName
                };

                await Mediator.SendAsync(new CreateVerse(verseData));

                Console.WriteLine("Created Verse:");
                Console.WriteLine(verseData);

            } while (Another());

            Footer();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "create verse",
            Description = "Create a new verse"
        };

    }
}

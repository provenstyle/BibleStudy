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

                var book    = await PromptForBook();
                var chapter = PromptForInt("Chapter:");
                var verse   = PromptForInt("Verse:");
                var text    = PromptForString("Text:");

                var verseData = new VerseData
                {
                    BookId = book.Id,
                    Chapter = chapter,
                    Number = verse,
                    Text = text,
                    CreatedBy = _config.UserName,
                    ModifiedBy = _config.UserName
                };

                await Mediator.SendAsync(new CreateVerse(verseData));

                Console.WriteLine("Created Verse");
                Console.WriteLine(verseData);

            } while (Another());
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "create verse",
            Description = "Create a new verse"
        };

    }
}

using System.Threading.Tasks;

namespace BibleStudy.Console.Commands
{
    using Data.Api;
    using Infrastructure;
    using MediatR;

    public class CreateVerseCommand : BaseCommand
    {
        private readonly IMediator _mediator;

        public CreateVerseCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override bool InternalCanProcess(string[] args)
        {
            return args.Length >= 2 &&
                   args[0] == "create" &&
                   args[1] == "verse";
        }

        public override async Task InternalProcess(string[] args)
        {
            await _mediator.SendAsync(new CreateVerse(new VerseData
            {
                BookId     = 1,
                Chapter    = 3,
                Number     = 16,
                Text       = "For God so loved the world that he gave his only begotten son...",
                CreatedBy  = "Michael Dudley",
                ModifiedBy = "Michael Dudley"
            }));

            System.Console.WriteLine("Created Verse");
        }
    }
}

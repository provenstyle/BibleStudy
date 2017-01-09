namespace BibleStudy.Console.Commands
{
    using System.Linq;
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;

    public class Quit : BaseCommand
    {
        public string[] Commands = {"quit", "quite", "q", "exit"};

        public Quit(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanHandle(string[] args)
        {
            return Commands.Contains(args[0]);
        }

        protected override Task InternalHandle(string[] args)
        {
            Header("Quiting");
            Quit = true;
            return Done();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "quit or q",
            Description = "Quit the application"
        };
    }
}
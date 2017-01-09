namespace BibleStudy.Console.Commands
{
    using System.Linq;
    using System.Threading.Tasks;
    using Infrastructure;

    public class Quit : BaseCommand
    {
        public string[] Commands = {"quit", "quite", "q", "exit"};

        protected override bool InternalCanProcess(string[] args)
        {
            return Commands.Contains(args[0]);
        }

        protected override Task InternalProcess(string[] args)
        {
            Header("Quiting");
            Quit = true;
            return Task.FromResult(true);
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "quit or q",
            Description = "Quit the application"
        };
    }
}
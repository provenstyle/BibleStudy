namespace BibleStudy.Console.Commands
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Infrastructure;

    public class Help : BaseCommand
    {
        private readonly IHelp[] _helps;

        public Help(IHelp[] helps)
        {
            _helps = helps;
        }

        protected override bool InternalCanProcess(string[] args)
        {
            return args[0] == "help";
        }

        protected override Task InternalProcess(string[] args)
        {
            Header("Help");
            _helps
                .Select(x => x.HelpData)
                .OrderBy(x => x.Command)
                .ForEach(x =>
                 {
                     Console.WriteLine($"{x.Command}\t - {x.Description}");
                 });

            return Task.FromResult(true);
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "help",
            Description = "Show help for all commands"
        };
    }
}

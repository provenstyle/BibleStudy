namespace BibleStudy.Console.Commands
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using Infrastructure;
    using MediatR;

    public class Help : BaseCommand
    {
        private readonly IHelp[] _helps;

        public Help(IMediator mediator, IHelp[] helps)
            : base(mediator)
        {
            _helps = helps;
        }

        protected override bool InternalCanHandle(string[] args)
        {
            return args[0] == "help";
        }

        protected override Task InternalHandle(string[] args)
        {
            Header("Help");

            var layout = new ColumnLayout(2);

            _helps
                .Select(x => x.HelpData)
                .OrderBy(x => x.Command)
                .ForEach(x =>
                 {
                     layout.Add(0, x.Command);
                     layout.Add(1, x.Description);
                 });

            Console.WriteLine(layout);

            Footer();

            return Done();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "help",
            Description = "Show help for all commands"
        };
    }
}

namespace BibleStudy.Console.Commands
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;

    public class Welcome : BaseCommand
    {
        public Welcome(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanProcess(string[] args)
        {
            return args[0] == "welcome";
        }

        protected override Task InternalProcess(string[] args)
        {
            var fileVersion = "unknown";
            var location = Assembly.GetExecutingAssembly().Location;
            if (location != null )
            {
                fileVersion = FileVersionInfo.GetVersionInfo(location).FileVersion;
            }

            Header($"Bible Study - {fileVersion}");
            Console.WriteLine("But his delight is in the law of the Lord,");
            Console.WriteLine("  And in His law he meditates day and night.");
            Console.WriteLine("Psalm 1:2");

            return Task.FromResult(true);
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "welcome",
            Description = "Show welcome message"
        };
    }
}

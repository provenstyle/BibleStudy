namespace BibleStudy.Console.Commands
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;
    using Miruken.Mvc.Console;

    public class WelcomeController : BaseCommand
    {
        public WelcomeController(IMediator mediator)
            : base(mediator)
        {
        }

        protected override bool InternalCanHandle(string[] args)
        {
            return args[0] == "welcome";
        }

        protected override Task InternalHandle(string[] args)
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
            Footer();

            return Done();
        }

        public void Test()
        {
            Show<OneView>();
        }

        public void ShowTwo()
        {
            Push<TwoController>().ShowTwo();
        }

        public override HelpData HelpData => new HelpData
        {
            Command     = "welcome",
            Description = "Show welcome message"
        };
    }

    public class OneView : View<WelcomeController>
    {
        public override void Activate()
        {
            ListenForKey();
        }

        public override void Loaded()
        {
            Header("View One");
            WriteLine($"Quit({ConsoleKey.Q}) | Next({ConsoleKey.N})");
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.N:
                    Controller.ShowTwo();
                    break;
                case ConsoleKey.Q:
                    BaseCommand.Quit = true;
                    break;
                default:
                    Unrecognized(key);
                    break;
            }
        }

        protected override void LineIn(string line)
        {
        }
    };

    public class TwoController : BaseCommand
    {
        public void ShowTwo()
        {
            Show<TwoView>();
        }

        public void Forward()
        {
            Push<ThreeController>().ShowThree();
        }

        public void Back()
        {
           EndContext();
        }

        public TwoController(IMediator mediator) : base(mediator)
        {
        }

        public override HelpData HelpData { get; }
        protected override bool InternalCanHandle(string[] args)
        {
            throw new NotImplementedException();
        }

        protected override Task InternalHandle(string[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class TwoView : View<TwoController>
    {
        public override void Activate()
        {
            ListenForKey();
        }

        public override void Loaded()
        {
            Header("View Two");
            WriteLine($"Back({ConsoleKey.B}) | Forward({ConsoleKey.F})");
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F:
                    Controller.Forward();
                    break;
                case ConsoleKey.B:
                    Controller.Back();
                    break;
                default:
                    Unrecognized(key);
                    break;
            }
        }

        protected override void LineIn(string input)
        {
        }
    }

    public class ThreeController : BaseCommand
    {
        public void ShowThree()
        {
            Show<ThreeView>();
        }

        public void Back()
        {
            EndContext();
        }

        public ThreeController(IMediator mediator) : base(mediator)
        {

        }

        public override HelpData HelpData { get; }
        protected override bool InternalCanHandle(string[] args)
        {
            throw new NotImplementedException();
        }

        protected override Task InternalHandle(string[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class ThreeView : View<ThreeController>
    {
        public override void Loaded()
        {
            Header("ThreeView");
            WriteLine("Back(b)");
        }

        public override void Activate()
        {
            ListenForKey();
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.B:
                    Controller.Back();
                    break;
                default:
                    Unrecognized(key);
                    break;
            }
        }

        protected override void LineIn(string input)
        {
        }
    }
}

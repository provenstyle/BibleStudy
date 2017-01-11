namespace BibleStudy.Console.Features.Home
{
    using System;
    using Infrastructure;
    using Miruken.Mvc.Console;

    public class OneView : View<OneController>
    {
        public override void Activate()
        {
            ListenForKey();
        }

        public override void Loaded()
        {
            Header("View One");
            Menu(
                new MenuItem("Quit",    ConsoleKey.Q),
                new MenuItem("Forward", ConsoleKey.F));
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F:
                    Controller.GoToViewTwo();
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
}
namespace BibleStudy.Console.Features.Home
{
    using System;
    using Miruken.Mvc.Console;

    public class TwoView : View<TwoController>
    {
        public override void Activate()
        {
            ListenForKey();
        }

        public override void Loaded()
        {
            Header("View Two");
            Menu(
                new MenuItem("Back",    ConsoleKey.B),
                new MenuItem("Forward", ConsoleKey.F));
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F:
                    Controller.GoToViewThree();
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
}
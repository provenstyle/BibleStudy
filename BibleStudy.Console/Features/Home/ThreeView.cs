namespace BibleStudy.Console.Features.Home
{
    using System;
    using Miruken.Mvc.Console;

    public class ThreeView : View<ThreeController>
    {
        public override void Loaded()
        {
            Header("View Three");
            Menu(new MenuItem("Back", ConsoleKey.B));
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
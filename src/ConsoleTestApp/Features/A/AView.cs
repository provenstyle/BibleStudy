namespace ConsoleTestApp.Features.A
{
    using System;
    using Miruken.Mvc.Console;

    public class AView : View<AController>
    {
        public override void Activate()
        {
            ListenForKey();
        }

        public override void Loaded()
        {
            Header("A View");
            WriteLine("A Feature");
            Block("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Menu(
                new MenuItem("Quit",    ConsoleKey.Q),
                new MenuItem("Forward", ConsoleKey.F));
        }

        protected override void KeyIn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F:
                    Controller.GoToBView();
                    break;
                case ConsoleKey.Q:
                    Controller.Quit();
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
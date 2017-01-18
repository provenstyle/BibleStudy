namespace ConsoleTestApp.Features.A
{
    using System;
    using Miruken.Mvc.Console;

    public class AView : View<AController>
    {
        private Menu menu;

        public override void Loaded()
        {
            Header("A View");
            WriteLine("A Feature");
            Block("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            menu = new Menu(
                new MenuItem("Quit",    ConsoleKey.Q, () => Controller.Quit()),
                new MenuItem("Forward", ConsoleKey.F, () => Controller.GoToBView()));
            WriteLine(menu.ToString());
        }

        public override void Activate()
        {
            ListenForMenu(menu);
        }

        protected override void LineIn(string line)
        {
            throw new NotImplementedException();
        }
    };
}
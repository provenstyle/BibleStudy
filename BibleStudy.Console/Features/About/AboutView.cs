namespace BibleStudy.Console.Features.About
{
    using System;
    using Miruken.Mvc.Console;

    public class AboutView : View<AboutController>
    {
        private Menu menu;

        public override void Loaded()
        {
            Header("About");
            Block($"Version {Controller.Version}");
            Block("Written by Michael Dudley");
            menu = new Menu(new MenuItem("Back", ConsoleKey.B, () => Controller.Back()));
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
    }
}

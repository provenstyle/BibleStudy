namespace BibleStudy.Console.Features.Verses
{
    using System;
    using Miruken.Mvc.Console;

    public class VersesView : View<VersesController>
    {
        private Menu menu;

        public override void Loaded()
        {
            Header("Verses");

            menu = new Menu(
                new MenuItem("List",   ConsoleKey.L, () => { }),
                new MenuItem("Create", ConsoleKey.C, () => { }),
                new MenuItem("Study",  ConsoleKey.S, () => { }),
                new MenuItem("Back",   ConsoleKey.B, () => Controller.Back()));

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
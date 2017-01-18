namespace BibleStudy.Console.Features.Home
{
    using System;
    using Miruken.Mvc.Console;
    public class HomeView : View<HomeController>
    {
        private Menu menu;

        public override void Loaded()
        {
            Header("Bible Study");
            WriteLine();
            WriteLine("But his delight is in the law of the Lord,");
            WriteLine("  And in His law he meditates day and night.");
            WriteLine("Psalm 1:2");
            WriteLine();

            menu = new Menu(
                    new MenuItem("Verses", ConsoleKey.V, () => Controller.GoToVerses()),
                    new MenuItem("Books",  ConsoleKey.B, async () => await Controller.GoToBooks()),
                    new MenuItem("About",  ConsoleKey.A, () => Controller.GoToAbout()),
                    new MenuItem("Quit",   ConsoleKey.Q, () => Controller.Quit()));
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

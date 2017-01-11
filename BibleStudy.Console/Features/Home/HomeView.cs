namespace BibleStudy.Console.Features.Home
{
    using System;
    using Miruken.Mvc.Console;

    public class HomeView : View<HomeController>
    {
        public override void Loaded()
        {
            Header($"Bible Study - {Controller.Version}");
            Console.WriteLine("But his delight is in the law of the Lord,");
            Console.WriteLine("  And in His law he meditates day and night.");
            Console.WriteLine("Psalm 1:2");
        }

        public override void Activate()
        {
        }

        protected override void LineIn(string line)
        {
        }

        protected override void KeyIn(ConsoleKey key)
        {
        }
    }
}

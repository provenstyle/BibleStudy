namespace BibleStudy.Console.Features.Home
{
    using System;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;
    public class HomeView : View<HomeController>
    {
        private readonly Menu   _menu;
        private readonly Buffer _buffer;

        public HomeView()
        {
            _buffer = new Buffer();
            Content = _buffer;

            _menu = new Menu(
                    new MenuItem("Verses", ConsoleKey.V, () => Controller.GoToVerses()),
                    new MenuItem("Books",  ConsoleKey.B, () => Controller.GoToBooks()),
                    new MenuItem("About",  ConsoleKey.A, () => Controller.GoToAbout()),
                    new MenuItem("Quit",   ConsoleKey.Q, () => Controller.Quit()));
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Bible Study");
            _buffer.WriteLine();
            _buffer.WriteLine("But his delight is in the law of the Lord,");
            _buffer.WriteLine("  And in His law he meditates day and night.");
            _buffer.WriteLine("Psalm 1:2");
            _buffer.WriteLine();
            _buffer.WriteLine(_menu.ToString());
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
        }
    }
}

namespace BibleStudy.Console.Features.Header
{
    using System;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class HeaderView : View<HeaderController>
    {
        private readonly Buffer _buffer;
        private readonly Menu   _menu;

        public HeaderView()
        {
            _buffer = new Buffer();
            Content = _buffer;
            _buffer.WriteLine("Bible Study");
            _buffer.WriteLine();
            _menu = new Menu(
                new MenuItem("Books",        ConsoleKey.B, () => Controller.GoToBooks()),
                new MenuItem("Verses",       ConsoleKey.V, () => Controller.GoToVerses()),
                new MenuItem("Observations", ConsoleKey.O, () => Controller.GoToObservations()),
                new MenuItem("Prayers",      ConsoleKey.P, () => Controller.GoToPrayers()),
                new MenuItem("Tags",         ConsoleKey.T, () => Controller.GoToTags()),
                new MenuItem("About",        ConsoleKey.A, () => Controller.GoToAbout()));
            _buffer.Write(_menu.ToString());

        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
        }
    }
}
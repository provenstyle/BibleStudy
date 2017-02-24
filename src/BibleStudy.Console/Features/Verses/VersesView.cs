namespace BibleStudy.Console.Features.Verses
{
    using System;
    using Miruken.Concurrency;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class VersesView : View<VersesController>
    {
        private readonly Menu   _menu;
        private readonly Buffer _buffer;

        public VersesView()
        {
            _buffer = new Buffer();
            Content = _buffer;
            _menu = new Menu(
                new MenuItem("List",   ConsoleKey.L, () => Promise.Empty),
                new MenuItem("Create", ConsoleKey.C, () => Promise.Empty),
                new MenuItem("Study",  ConsoleKey.S, () => Promise.Empty),
                new MenuItem("Back",   ConsoleKey.B, () => Controller.Back()));
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Verses");
            _buffer.WriteLine(_menu.ToString());
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
        }
    }
}
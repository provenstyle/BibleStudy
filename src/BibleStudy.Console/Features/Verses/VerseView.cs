namespace BibleStudy.Console.Features.Verses
{
    using System;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class VerseView : View<VerseController>
    {
        private Buffer _buffer;
        private Menu   _menu;

        public VerseView()
        {
            _buffer = new Buffer();
            Content = _buffer;
            _menu = new Menu(
                new MenuItem("Edit",  ConsoleKey.E, () => Controller.GoToUpdateVerse()),
                new MenuItem("Study", ConsoleKey.S, () => Controller.GoToStudy())
                );
        }

        public override void Initialize()
        {
            base.Initialize();
            var verse = Controller.Verse;

            _buffer.WriteLine("Verse");
            _buffer.WriteLine();
            _buffer.WriteLine(_menu.ToString());
            _buffer.WriteLine();
            _buffer.WriteLine(verse.ToString());
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
        }
    }
}

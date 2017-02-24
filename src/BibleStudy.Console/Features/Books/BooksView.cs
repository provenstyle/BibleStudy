namespace BibleStudy.Console.Features.Books
{
    using System;
    using Infrastructure;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class BooksView : View<BooksController>
    {
        private readonly Menu _menu;
        private readonly Buffer _buffer;

        public BooksView()
        {
            _buffer = new Buffer();
            Content = _buffer;
            _menu = new Menu(new MenuItem("Back", ConsoleKey.B, () => Controller.Back()));
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Books");
            _buffer.WriteLine();
            _buffer.WriteLine(_menu.ToString());
            _buffer.WriteLine();

            var layout = new ColumnLayout(2);
            foreach (var book in Controller.OldTestament)
            {
                layout.Add(0, $"{book.Id:00} - {book.Name}");
            }
            foreach (var book in Controller.NewTestament)
            {
                layout.Add(1, $"{book.Id:00} - {book.Name}");
            }
            _buffer.WriteLine(layout.ToString());
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
        }
    }
}
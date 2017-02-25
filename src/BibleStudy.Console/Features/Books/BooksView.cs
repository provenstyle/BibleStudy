namespace BibleStudy.Console.Features.Books
{
    using System;
    using Infrastructure;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class BooksView : View<BooksController>
    {
        private readonly Buffer _buffer;

        public BooksView()
        {
            _buffer = new Buffer();
            Content = _buffer;
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Books");
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
    }
}
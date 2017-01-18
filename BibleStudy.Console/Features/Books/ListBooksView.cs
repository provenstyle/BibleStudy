namespace BibleStudy.Console.Features.Books
{
    using System;
    using Infrastructure;
    using Miruken.Mvc.Console;

    public class ListBooksView : View<ListBooksController>
    {
        private Menu _menu;

        public override void Loaded()
        {
            Header("Books");

            var layout = new ColumnLayout(2);
            foreach (var book in Controller.OldTestament)
            {
                layout.Add(0, $"{book.Id:00} - {book.Name}");
            }
            foreach (var book in Controller.NewTestament)
            {
                layout.Add(1, $"{book.Id:00} - {book.Name}");
            }
            WriteLine(layout.ToString());

            _menu = new Menu(new MenuItem("Back", ConsoleKey.B, () => Controller.Back()));
            WriteLine(_menu.ToString());
        }

        public override void Activate()
        {
            ListenForMenu(_menu);
        }

        protected override void LineIn(string line)
        {
        }
    }
}
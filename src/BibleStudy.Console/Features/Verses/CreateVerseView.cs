using System.Linq;

namespace BibleStudy.Console.Features.Verses
{
    using System;
    using Miruken.Mvc.Console;
    using Miruken.Mvc.Console.Forms;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class CreateVerseView : View<CreateVerseController>
    {
        private readonly Buffer _buffer;

        private Form _form;

        public CreateVerseView()
        {
            _buffer = new Buffer();
            Content = _buffer;

            _buffer.WriteLine("Create Verse");
            _buffer.WriteLine();
        }

        public void FillOutForm()
        {
            _form = new Form(new Input[]
            {
                new InputList("Book", Controller.Books.Select(x => x.Name).ToArray(), s =>
                {
                    var book = Controller.Books.FirstOrDefault(b => b.Name.Equals(s, StringComparison.InvariantCultureIgnoreCase));
                    Controller.Verse.BookId = book?.Id;
                }),
                new Question("Chapter?", x => Controller.Verse.Chapter = int.Parse(x))
                    .Number(),
                new Question("Number?",   x => Controller.Verse.Number = int.Parse(x))
                    .Number(),
                new Question("Text", "", x => Controller.Verse.Text = x)
                    .Required("Verse text is required.")
            });

            _form.Handle(_buffer, InputLocation.Inline);
        }
    }
}

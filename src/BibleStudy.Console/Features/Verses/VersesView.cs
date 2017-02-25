namespace BibleStudy.Console.Features.Verses
{
    using System;
    using Data.Api.Verses;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class VersesView : View<VersesController>
    {
        private readonly Menu   _menu;
        private readonly Buffer _buffer;
        private SelectList<VerseData> _selectList;

        public VersesView()
        {
            _buffer = new Buffer();
            Content = _buffer;
            _menu = new Menu(
                new MenuItem("Create", ConsoleKey.C, () => Controller.GoToCreateVerse()));
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Verses");
            _buffer.WriteLine();
            _buffer.WriteLine(_menu.ToString());
            _buffer.Seperator();
            _buffer.WriteLine();

            _selectList = new SelectList<VerseData>(Controller.Verses, v =>
            {
                Controller.GoToVerse(v);
            });
            _buffer.WriteLine(_selectList.ToString());
        }

        public override void KeyPressed(ConsoleKeyInfo keyInfo)
        {
            base.KeyPressed(keyInfo);
            _menu.Listen(keyInfo);
            _selectList.Listen(keyInfo);
        }
    }
}
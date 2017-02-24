namespace BibleStudy.Console.Features.About
{
    using System;
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;

    public class AboutView : View<AboutController>
    {
        private readonly Buffer _buffer;

        public AboutView()
        {
            _buffer = new Buffer();
            Content = _buffer;
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("About");
            _buffer.WriteLine();
            _buffer.WriteLine("Bible Study");
            _buffer.WriteLine($"Version {Controller.Version}");
            _buffer.WriteLine("Written by Michael Dudley");
        }
    }
}

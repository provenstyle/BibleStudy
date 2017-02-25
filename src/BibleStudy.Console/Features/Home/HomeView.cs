namespace BibleStudy.Console.Features.Home
{
    using Miruken.Mvc.Console;
    using Buffer = Miruken.Mvc.Console.Buffer;
    public class HomeView : View<HomeController>
    {
        private readonly Buffer _buffer;

        public HomeView()
        {
            _buffer = new Buffer();
            Content = _buffer;
        }

        public override void Initialize()
        {
            base.Initialize();
            _buffer.WriteLine("Bible Study");
            _buffer.WriteLine();
            _buffer.WriteLine("But his delight is in the law of the Lord,");
            _buffer.WriteLine("  And in His law he meditates day and night.");
            _buffer.WriteLine();
            _buffer.WriteLine("Psalm 1:2");
        }
    }
}

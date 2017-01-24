namespace Miruken.Mvc.Console.Test
{
    public class TestBase
    {
        public Cells Render(Size size, FrameworkElement buffer, Point point = null)
        {
            var cells = new Cells(size);
            buffer.Measure(size);
            buffer.Arrange(new Rectangle(point ?? new Point(0,0), size));
            buffer.Render(cells);
            return cells;
        }
    }
}
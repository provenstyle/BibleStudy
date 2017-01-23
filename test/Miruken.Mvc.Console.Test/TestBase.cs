namespace Miruken.Mvc.Console.Test
{
    public class TestBase
    {
        public Cells Render(Size size, FrameworkElement buffer)
        {
            var cells = new Cells(size);
            buffer.Measure(size);
            buffer.Arrange(new Rectangle(new Point(0,0), size));
            buffer.Render(cells);
            return cells;
        }
    }
}
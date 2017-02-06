namespace Miruken.Mvc.Console.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class TestBase
    {
        public Cells Render(Size size, FrameworkElement buffer, Point point = null)
        {
            var cells = new Cells(size.Height, size.Width, point, '*');
            buffer.Measure(size);
            buffer.Arrange(new Rectangle(point ?? new Point(0,0), size));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());
            return cells;
        }

        public void AssertCellsAreEquivelant(char[][] expected, Cells cells)
        {
            Assert.AreEqual(expected.Length, cells.Height);
            for (var i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], cells[i]);
            }
        }
    }
}
namespace Miruken.Mvc.Console
{
    using System;

    public class Window
    {
        public static Cells Cells;

        public FrameworkElement Content { get; set; }

        public void Update()
        {
            var size = new Size(Console.WindowWidth, Console.WindowHeight);
            var cells = new Cells(size);
            Content.Measure(size);
            Content.Arrange(new Rectangle(new Point(0,0), size));
            Content.Render(cells);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Cells.ToString());
        }
    }
}

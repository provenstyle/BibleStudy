namespace Miruken.Mvc.Console
{
    using System;

    public class RenderPanel<T>: Render where T : IHaveFrameworkElement
    {
        public string Handle(Panel<T> panel)
        {
            return Handle(Console.WindowWidth, Console.WindowHeight, panel);
        }
        public string Handle(int width, int height, Panel<T> panel)
        {
            _cells  = new Cells(panel.ActualSize.Height, panel.ActualSize.Width);

            foreach (var child in panel.Children)
            {
                var size = new Size(panel.ActualSize.Width, panel.ActualSize.Height);
                child.Element.Measure(size);
            }
            foreach (var child in panel.Children)
            {
                var rectangle = new Rectangle();
                child.Element.Arrange(rectangle);
            }

            return "foo";
        }
    }
}
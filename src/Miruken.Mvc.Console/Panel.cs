namespace Miruken.Mvc.Console
{
    using System;
    using System.Collections.Generic;

    public class Panel: FrameworkElement
    {
        public List<FrameworkElement> Children { get; set; }

        public Panel()
        {
            Children = new List<FrameworkElement>();
        }
    }

    public class StackPanel : Panel
    {
        public override void Measure(Size availableSize)
        {
            DesiredSize =  MeasureOverride(availableSize);
            var available = new Size(DesiredSize);
            foreach (var child in Children)
            {
                child.Measure(available);
                available.Height -= child.DesiredSize.Height;
            }
        }

        public override void Arrange(Rectangle rectangle)
        {
            ActualSize = ArrangeOverride(rectangle.Size);
            Point = rectangle.Location;
            var height = rectangle.Height/Children.Count;
            var point  = new Point(rectangle.Location);
            foreach (var child in Children)
            {
                child.ActualSize = new Size(rectangle.Width, height);
                child.Point      = new Point(point);
                point.Y         += child.ActualSize.Height;
            }
        }

        public override void Render(Cells cells)
        {
            base.Render(cells);
            foreach (var child in Children)
            {
                child.Render(cells);
            }
        }
    }

    public class RenderPanel: Render
    {
        private Panel _panel;

        public string Handle(Panel panel)
        {
            return Handle(Console.WindowWidth, Console.WindowHeight, panel);
        }
        public string Handle(int width, int height, Panel panel)
        {
            _panel =  panel;
            _cells  = new Cells(panel.ActualSize.Height, panel.ActualSize.Width);

            foreach (var child in panel.Children)
            {
                var size = new Size(panel.ActualSize.Width, panel.ActualSize.Height);
                child.Measure(size);
            }
            foreach (var child in panel.Children)
            {
                var rectangle = new Rectangle();
                child.Arrange(rectangle);
            }

            return "foo";
        }
    }
}

namespace Miruken.Mvc.Console
{
    using System;

    public class DockPanel: Panel<DockChild>
    {
        public void Add(DockChild child)
        {
            Children.Add(child);
        }

        public override void Measure(Size availableSize)
        {
            base.Measure(availableSize);
            foreach (var child in Children)
            {
                child.Element.Measure(DesiredSize);
            }
        }

        public override void Arrange(Rectangle rectangle)
        {
            base.Arrange(rectangle);

            var arrangeOverride = ArrangeOverride(rectangle.Size);
            if (arrangeOverride != null) return;

            ActualSize = new Size(rectangle.Size);
            Point = rectangle.Location;

            var xStart = Point.X + Margin.Left + Border.Left   + Padding.Left;
            var yStart = Point.Y + Margin.Top  + Border.Top    + Padding.Top;
            var xEnd   = rectangle.Size.Width  - Margin.Right  - Border.Right  - Padding.Right;
            var yEnd   = rectangle.Size.Height - Margin.Bottom - Border.Bottom - Padding.Bottom;
            var boundry = new Boundry(new Point(xStart, yStart), new Point(xEnd, yEnd));

            foreach (var child in Children)
            {
                switch (child.Dock)
                {
                    case Dock.Left:
                        break;
                    case Dock.Top:
                        DockTop(child, boundry);
                        break;
                    case Dock.Right:
                        break;
                    case Dock.Bottom:
                        break;
                    case Dock.Fill:
                        DockFill(child, boundry);
                        break;
                }
            }
        }


        public void DockTop(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.ActualSize.Height =
                (int)Math.Floor(boundry.Height*child.Percent*.01M);

            switch (element.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    element.ActualSize.Width = boundry.Width;
                    break;
                case HorizontalAlignment.Center:
                    element.ActualSize.Width = boundry.Width;
                    break;
                case HorizontalAlignment.Right:
                    element.ActualSize.Width = boundry.Width;
                    break;
                case HorizontalAlignment.Stretch:
                    element.ActualSize.Width = boundry.Width;
                    break;
            }

            element.Point = new Point(boundry.Start.X, boundry.Start.Y);
            element.Arrange(boundry.Rectangle);
            boundry.Start.Y += element.ActualSize.Height;
        }

        public void DockFill(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.ActualSize.Height = boundry.Height;
            element.ActualSize.Width = boundry.Width;
            element.Point = new Point(boundry.Start.X, boundry.Start.Y);
        }
    }
}
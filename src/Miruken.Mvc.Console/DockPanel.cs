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
                child.Element.Measure(DesiredSize);
        }

        public override void Arrange(Rectangle rectangle)
        {
            base.Arrange(rectangle);

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
                        DockLeft(child, boundry);
                        break;
                    case Dock.Top:
                        DockTop(child, boundry);
                        break;
                    case Dock.Right:
                        DockRight(child, boundry);
                        break;
                    case Dock.Bottom:
                        DockBottom(child, boundry);
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
            element.DesiredSize.Height =
                (int)Math.Floor(boundry.Height*child.Percent*.01M);
            var xOffset = 0;

            switch (element.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    if (element.DesiredSize.Width < boundry.Width && (boundry.Width -element.DesiredSize.Width)%2 > 0)
                        element.DesiredSize.Width++;

                    xOffset = (boundry.Width - element.DesiredSize.Width)/2;
                    break;
                case HorizontalAlignment.Right:
                    xOffset = boundry.Width - element.DesiredSize.Width;
                    break;
                case HorizontalAlignment.Stretch:
                case HorizontalAlignment.Unknown:
                    element.DesiredSize.Width = boundry.Width;
                    break;
            }

            element.Arrange(new Rectangle(
                new Point(boundry.Start.X + xOffset, boundry.Start.Y),
                new Size(boundry.Width, boundry.Height)));
            boundry.Start.Y += element.ActualSize.Height;
        }

        public void DockBottom(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.DesiredSize.Height =
                (int)Math.Floor(boundry.Height*child.Percent*.01M);
            var xOffset = 0;

            switch (element.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    if (element.DesiredSize.Width < boundry.Width && (boundry.Width -element.DesiredSize.Width)%2 > 0)
                        element.DesiredSize.Width++;

                    xOffset = (boundry.Width - element.DesiredSize.Width)/2;
                    break;
                case HorizontalAlignment.Right:
                    xOffset = boundry.Width - element.DesiredSize.Width;
                    break;
                case HorizontalAlignment.Stretch:
                case HorizontalAlignment.Unknown:
                    element.DesiredSize.Width = boundry.Width;
                    break;
            }

            element.Arrange(new Rectangle(
                new Point(boundry.Start.X + xOffset, boundry.End.Y - element.DesiredSize.Height),
                new Size(boundry.Width, boundry.Height)));
            boundry.End.Y -= element.ActualSize.Height;
        }

        public void DockLeft(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.DesiredSize.Width =
                (int)Math.Floor(boundry.Width*child.Percent*.01M);
            var yOffset = 0;

            switch (element.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    break;
                case VerticalAlignment.Center:
                    if ( element.DesiredSize.Height < boundry.Height && (boundry.Height - element.DesiredSize.Height)%2 > 0)
                        element.DesiredSize.Height++;

                    yOffset = (boundry.Height - element.DesiredSize.Height)/2;
                    break;
                case VerticalAlignment.Bottom:
                    yOffset = boundry.Height - element.DesiredSize.Height;
                    break;
                case VerticalAlignment.Stretch:
                case VerticalAlignment.Unknown:
                    element.DesiredSize.Height = boundry.Height;
                    break;
            }

            element.Arrange(new Rectangle(
                new Point(boundry.Start.X, boundry.Start.Y + yOffset),
                new Size(boundry.Width, boundry.Height)));
            boundry.Start.X += element.ActualSize.Width;
        }

        public void DockRight(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.DesiredSize.Width =
                (int)Math.Floor(boundry.Width*child.Percent*.01M);
            var yOffset = 0;

            switch (element.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    yOffset = boundry.Height - element.DesiredSize.Height;
                    break;
                case VerticalAlignment.Center:
                    if ( element.DesiredSize.Height < boundry.Height && (boundry.Height - element.DesiredSize.Height)%2 > 0)
                        element.DesiredSize.Height++;

                    yOffset = (boundry.Height - element.DesiredSize.Height)/2;
                    break;
                case VerticalAlignment.Bottom:
                    break;
                case VerticalAlignment.Stretch:
                case VerticalAlignment.Unknown:
                    element.DesiredSize.Height = boundry.Height;
                    break;
            }

            var rect = new Rectangle(
                new Point(boundry.End.X - element.DesiredSize.Width, boundry.End.Y - element.DesiredSize.Height - yOffset),
                new Size(boundry.Width, boundry.Height));
            element.Arrange(rect);
            boundry.End.X -= element.ActualSize.Width;
        }

        public void DockFill(DockChild child, Boundry boundry)
        {
            var element = child.Element;
            element.DesiredSize.Height = boundry.Height;
            element.DesiredSize.Width  = boundry.Width;
            element.Point = new Point(boundry.Start.X, boundry.Start.Y);
            element.Arrange(boundry.Rectangle);
        }
    }
}
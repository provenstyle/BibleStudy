namespace Miruken.Mvc.Console
{
    public class StackPanel : Panel<StackChild>
    {
        public void Add(FrameworkElement child)
        {
            Children.Add(new StackChild(child));
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
                var element = child.Element;
                var xOffset = 0;
                var yOffset = 0;

                switch (element.HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        break;
                    case HorizontalAlignment.Center:
                        if (element.DesiredSize.Width < boundry.Width && (boundry.Width - element.DesiredSize.Width)%2 > 0 )
                            element.DesiredSize.Width++;
                        xOffset = (boundry.Width - element.DesiredSize.Width)/2;
                        break;
                    case HorizontalAlignment.Right:
                        if (element.DesiredSize.Width < boundry.Width)
                            boundry.Start.X = boundry.End.X - element.DesiredSize.Width;
                        break;
                    default:
                        child.Element.DesiredSize.Width = boundry.Width;
                        break;
                }

                switch (element.VerticalAlignment)
                {
                    case VerticalAlignment.Top:
                        break;
                    case VerticalAlignment.Center:
                        if (element.DesiredSize.Height < boundry.Height && (boundry.Height - element.DesiredSize.Height)%2 > 0)
                            element.DesiredSize.Height++;
                        yOffset = (boundry.Height - element.DesiredSize.Height)/2;
                        break;
                    case VerticalAlignment.Bottom:
                        if (element.DesiredSize.Height < boundry.Height)
                            boundry.Start.Y = boundry.End.Y - element.DesiredSize.Height;
                        break;
                    default:
                        child.Element.DesiredSize.Height = boundry.Height;
                        break;
                }

                element.Arrange(new Rectangle(
                    new Point(boundry.Start.X + xOffset, boundry.Start.Y + yOffset),
                    new Size(boundry.Width, boundry.Height)));
            }
        }
    }
}
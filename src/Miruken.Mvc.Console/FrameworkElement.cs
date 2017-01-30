namespace Miruken.Mvc.Console
{
    using System;

    public abstract class FrameworkElement
    {
        public Size                Size                { get; set; }
        public Size                DesiredSize         { get; set; }
        public Size                ActualSize          { get; set; }
        public Thickness           Margin              { get; set; }
        public Thickness           Border              { get; set; }
        public Thickness           Padding             { get; set; }
        public Point               Point               { get; set; }
        public VerticalAlignment   VerticalAlignment   { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }

        protected FrameworkElement()
        {
            Point       = Point.Default;
            Margin      = Thickness.Default;
            Border      = Thickness.Default;
            Padding     = Thickness.Default;
            Size        = Size.Default;
            DesiredSize = Size.Default;
            ActualSize  = Size.Default;
        }

        public virtual void Measure(Size availableSize)
        {
            var measureOverride = MeasureOverride(availableSize);
            if (measureOverride != null)
            {
                DesiredSize = new Size(measureOverride);
                return;
            }

            var height = Size.Height > availableSize.Height
               ? availableSize.Height
               : Size.Height;
            var width = Size.Width > availableSize.Width
               ? availableSize.Width
               : Size.Width;

            DesiredSize = new Size(Math.Max(width, 0),  Math.Max(height, 0));
        }

        public virtual Size MeasureOverride(Size availableSize)
        {
            return null;
        }

        public virtual void Arrange(Rectangle rectangle)
        {
            Point      = rectangle.Location;
            var overrideSize = ArrangeOverride(rectangle.Size);
            ActualSize = overrideSize ?? DesiredSize;
        }

        public virtual Size ArrangeOverride(Size finalSize)
        {
            return null;
        }

        public virtual void Render(Cells cells)
        {
            new RenderElement().Handle(this, cells);
        }

        public bool CanRenderBorderAndPadding()
        {
            return ActualSize?.Height >= 3 && ActualSize?.Width >= 3;
        }
    }
}

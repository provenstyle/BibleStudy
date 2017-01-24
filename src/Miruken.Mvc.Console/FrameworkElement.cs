namespace Miruken.Mvc.Console
{
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
            DesiredSize = MeasureOverride(availableSize);
        }

        public virtual Size MeasureOverride(Size availableSize)
        {
            return availableSize;
        }

        public virtual void Arrange(Rectangle rectangle)
        {
            Point      = rectangle.Location;
            ActualSize = ArrangeOverride(rectangle.Size);
        }

        public virtual Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
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

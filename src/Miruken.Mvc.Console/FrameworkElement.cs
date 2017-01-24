namespace Miruken.Mvc.Console
{
    public abstract class FrameworkElement
    {
        public Size                Size                { get; set; }
        public Size                DesiredSize         { get; set; }
        public Size                ActualSize          { get; set; }
        public Thickness           Margin              { get; set; }
        public Point               Point               { get; set; }
        public VerticalAlignment   VerticalAlignment   { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }

        public int PadLeft      { get; set; }
        public int PadTop       { get; set; }
        public int PadRight     { get; set; }
        public int PadBottom    { get; set; }

        public int BorderLeft   { get; set; }
        public int BorderTop    { get; set; }
        public int BorderRight  { get; set; }
        public int BorderBottom { get; set; }

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

        public FrameworkElement Border(int border)
        {
            return Border(border, border);
        }

        public FrameworkElement Border(int LeftRight, int TopBottom )
        {
            return Border(LeftRight, TopBottom, LeftRight, TopBottom);
        }

        public FrameworkElement Border(int Left, int Top, int Right, int Bottom )
        {
            BorderLeft   = Left;
            BorderTop    = Top;
            BorderRight  = Right;
            BorderBottom = Bottom;
            return this;
        }

        public FrameworkElement Padding(int padding)
        {
            return Padding(padding, padding);
        }

        public FrameworkElement Padding(int LeftRight, int TopBottom )
        {
            return Padding(LeftRight, TopBottom, LeftRight, TopBottom);
        }

        public FrameworkElement Padding(int Left, int Top, int Right, int Bottom )
        {
            PadLeft   = Left;
            PadTop    = Top;
            PadRight  = Right;
            PadBottom = Bottom;
            return this;
        }

        public bool CanRenderBorderAndPadding()
        {
            return ActualSize?.Height >= 3 && ActualSize?.Width >= 3;
        }
    }
}

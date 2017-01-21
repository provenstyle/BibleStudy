namespace Miruken.Mvc.Console
{
    using System;
    using System.Collections.Generic;

    public class Transform
    {
        public Cells Cells { get; set; }
    }

    public abstract class Visual: OutputBuffer
    {
        public Vector VisualOffset { get; set; }
        public List<Transform> Transforms { get; set; }
    }

    public abstract class FrameworkElement: Visual
    {
        public Size                Size                { get; set; }
        public Size                DesiredSize         { get; set; }
        public Size                Rendered            { get; set; }
        public Thickness           Margin              { get; set; }
        public VerticalAlignment   VerticalAlignment   { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }

        public virtual void Measure(Size availableSize)
        {
            DesiredSize = availableSize;
        }

        public virtual Size MeasureOverride(Size availableSize)
        {
            return availableSize;
        }

        public virtual void Arrange(Rectangle rectangle)
        {
            VisualOffset = new Vector(rectangle.Location.X, rectangle.Location.Y);
            Rendered = ArrangeOverride(rectangle.Size);
        }

        public virtual Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
        }

        public Cells Layout()
        {
            throw new NotImplementedException();
        }
    }
}

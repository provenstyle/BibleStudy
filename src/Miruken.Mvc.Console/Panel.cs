namespace Miruken.Mvc.Console
{
    using System.Collections.Generic;

    public interface IHaveFrameworkElement
    {
        FrameworkElement Element { get; set; }
    }

    public class Panel<T>: FrameworkElement where T: IHaveFrameworkElement
    {
        public List<T> Children { get; set; }

        public Panel()
        {
            Children = new List<T>();
        }

        public override void Render(Cells cells)
        {
            base.Render(cells);
            foreach (var child in Children)
            {
                child.Element.Render(cells);
            }
        }
    }

    public class StackChild : IHaveFrameworkElement
    {
        public FrameworkElement Element { get; set; }

        public StackChild(FrameworkElement element)
        {
            Element = element;
        }
    }

    public class StackPanel : Panel<StackChild>
    {
        public override void Measure(Size availableSize)
        {
            DesiredSize =  MeasureOverride(availableSize);
            var available = new Size(DesiredSize);
            foreach (var child in Children)
            {
                child.Element.Measure(available);
                available.Height -= child.Element.DesiredSize.Height;
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
                child.Element.ActualSize = new Size(rectangle.Width, height);
                child.Element.Point      = new Point(point);
                point.Y         += child.Element.ActualSize.Height;
            }
        }

        public void Add(FrameworkElement child)
        {
            Children.Add(new StackChild(child));
        }
    }
}

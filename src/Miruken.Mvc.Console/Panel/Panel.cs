namespace Miruken.Mvc.Console
{
    using System.Collections.Generic;

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
}

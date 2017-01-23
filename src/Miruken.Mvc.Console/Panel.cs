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

        public override void Render(Cells cells)
        {
            throw new NotImplementedException();
        }
    }

    public class StackPanel : Panel
    {
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
            _cells  = new Cells((int)panel.Rendered.Height, (int)panel.Rendered.Width);

            foreach (var child in panel.Children)
            {
                var size = new Size(panel.Rendered.Width, panel.Rendered.Height);
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

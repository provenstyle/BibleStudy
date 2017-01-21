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
            Size     = Size.Empty;
        }
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
            _width =  width;
            _height = height;
            _cells  = new Cells(_height, _width);

            foreach (var child in panel.Children)
            {
                var size = new Size(_width, _height);
                child.Measure(size);
            }
            foreach (var child in panel.Children)
            {
                var rectangle = new Rectangle();
                child.Arrange(rectangle);
            }
            var layout = panel.Layout();
            return "foo";
        }
    }
}

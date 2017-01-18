namespace Miruken.Mvc.Console
{
    public class Element: OutputBuffer
    {
        public OutputBuffer OutputBuffer { get; set; }

        public int PadLeft      { get; set; }
        public int PadTop       { get; set; }
        public int PadRight     { get; set; }
        public int PadBottom    { get; set; }

        public int BorderLeft   { get; set; }
        public int BorderTop    { get; set; }
        public int BorderRight  { get; set; }
        public int BorderBottom { get; set; }

        public Element Border(int border)
        {
            return Border(border, border);
        }

        public Element Border(int LeftRight, int TopBottom )
        {
            return Border(LeftRight, TopBottom, LeftRight, TopBottom);
        }

        public Element Border(int Left, int Top, int Right, int Bottom )
        {
            BorderLeft   = Left;
            BorderTop    = Top;
            BorderRight  = Right;
            BorderBottom = Bottom;
            return this;
        }

        public Element Padding(int padding)
        {
            return Padding(padding, padding);
        }

        public Element Padding(int LeftRight, int TopBottom )
        {
            return Padding(LeftRight, TopBottom, LeftRight, TopBottom);
        }

        public Element Padding(int Left, int Top, int Right, int Bottom )
        {
            PadLeft   = Left;
            PadTop    = Top;
            PadRight  = Right;
            PadBottom = Bottom;
            return this;
        }

        public override char[][] Render(int width, int height)
        {
            var output = base.Render(width, height);
            return new RenderElement().Handle(width, height, this, output);
        }
    }
}
namespace Miruken.Mvc.Console
{
    public class Rectangle
    {
        public Point  Location { get; set; }
        public double Height   { get; set; }
        public double Width    { get; set; }

        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }
            set
            {
                Height = value.Height;
                Width  = value.Width;
            }
        }
    }
}
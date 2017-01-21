namespace Miruken.Mvc.Console
{
    public class Size
    {
        public static Size Empty = new Size(double.NaN, double.NaN);
        public double Width  { get; set; }
        public double Height { get; set; }

        public Size()
        {
        }

        public Size(double width, double height)
        {
            Width  = width;
            Height = height;
        }
    }
}
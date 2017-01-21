namespace Miruken.Mvc.Console
{
    public abstract class Render
    {
        public int   _width  { get; set; }
        public int   _height { get; set; }
        public Cells _cells  { get; set; }
    }
}
namespace Miruken.Mvc.Console
{
    public class Boundry
    {
        public Boundry(Point start, Point end)
        {
            Start = start;
            End   = end;
        }

        public Point Start { get; set; }
        public Point End   { get; set; }
    }
}
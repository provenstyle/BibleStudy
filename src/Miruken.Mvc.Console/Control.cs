namespace Miruken.Mvc.Console
{
    public class ContentControl: FrameworkElement
    {
        public FrameworkElement Content { get; set; }
        public override void Render(Cells cells)
        {
            Content.Render(cells);
        }
    }

}
namespace Miruken.Mvc.Console
{
    public class StackChild : IHaveFrameworkElement
    {
        public FrameworkElement Element { get; set; }

        public StackChild(FrameworkElement element)
        {
            Element = element;
        }
    }
}
namespace Miruken.Mvc.Console.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Foo
    {
        [TestMethod]
        public void Bar()
        {
            var window = new Window();
            var panel = new Panel();
            var contentA = new OutputBuffer();
            contentA.WriteLine("Hello World");

            var contentB = new OutputBuffer();
            contentB.WriteLine("Howdy World");
            panel.Children.Add(contentA);
            panel.Children.Add(contentB);
            window.Content = panel;
        }
    }
}

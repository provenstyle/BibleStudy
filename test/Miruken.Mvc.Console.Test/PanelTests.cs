namespace Miruken.Mvc.Console.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PanelTests: TestBase
    {
        [TestMethod]
        public void Foo()
        {
            var main = new StackPanel
            {
                Size = new Size(10, 10)
            };
            var first = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment   = VerticalAlignment.Stretch,
                Border              = new Thickness(1)
            };

            var second = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment   = VerticalAlignment.Stretch,
                Border              = new Thickness(1)
            };

            main.Children.Add(first);
            main.Children.Add(second);

            var cells = Render(main.Size, main);
        }

    }
}

namespace Miruken.Mvc.Console.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PanelTests
    {
        [TestMethod]
        public void Foo()
        {
            var main = new Panel
            {
                Size = new Size(100, 100)
            };
            var left = new Panel
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment   = VerticalAlignment.Stretch
            };

            var right = new Panel
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment   = VerticalAlignment.Stretch
            };

            main.Children.Add(left);
            main.Children.Add(right);

            Console.WriteLine(new RenderPanel().Handle(50, 20, main));
        }

    }
}

namespace Miruken.Mvc.Console.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DockPanelTopTests: TestBase
    {
        [TestMethod]
        public void DockTopStretch()
        {
            Assert(HorizontalAlignment.Stretch, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            });
        }

        [TestMethod]
        public void DockTopUnknown()
        {
            Assert(HorizontalAlignment.Unknown, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            });
        }

        [TestMethod]
        public void DockTopLeft()
        {
            Assert(HorizontalAlignment.Left, new []
            {
                new [] {'-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' '},
                new [] {'|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' '},
                new [] {'-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' '},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            });
        }

        [TestMethod]
        public void DockTopCenter()
        {
            Assert(HorizontalAlignment.Center, new []
            {
                new [] {' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new [] {' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' '},
                new [] {' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            });
        }

        [TestMethod]
        public void DockTopRight()
        {
            Assert(HorizontalAlignment.Right, new []
            {
                new [] {' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-'},
                new [] {' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|'},
                new [] {' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            });
        }

        public void Assert(HorizontalAlignment horizontalAlignment, char[][] expected)
        {
            var main = new DockPanel()
            {
                Size = new Size(10, 10)
            };
            var header = new DockChild()
            {
                Element = new DockPanel {
                    Border              = new Thickness(1),
                    HorizontalAlignment = horizontalAlignment,
                    Size                = new Size(5, 5)
                },
                Dock = Dock.Top,
                Percent = 30
            };

            var content = new DockChild()
            {
                Element = new DockPanel {
                    Border = new Thickness(1)
                },
                Dock = Dock.Fill
            };

            main.Add(header);
            main.Add(content);

            var cells = Render(main.Size, main);

            AssertCellsAreEquivelant(expected, cells);
        }

    }

    [TestClass]
    public class DockPanelBottomTests: TestBase
    {
        [TestMethod]
        public void DockBottomStretch()
        {
            Assert(HorizontalAlignment.Stretch, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
            });
        }

        [TestMethod]
        public void DockBottomUnknown()
        {
            Assert(HorizontalAlignment.Unknown, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
            });
        }

        [TestMethod]
        public void DockBottomLeft()
        {
            Assert(HorizontalAlignment.Left, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' '},
                new [] {'|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' '},
                new [] {'-', '-', '-', '-', '-', ' ', ' ', ' ', ' ', ' '}
            });
        }

        [TestMethod]
        public void DockBottomCenter()
        {
            Assert(HorizontalAlignment.Center, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new [] {' ', ' ', '|', ' ', ' ', ' ', ' ', '|', ' ', ' '},
                new [] {' ', ' ', '-', '-', '-', '-', '-', '-', ' ', ' '}
            });
        }

        [TestMethod]
        public void DockBottomRight()
        {
            Assert(HorizontalAlignment.Right, new []
            {
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                new [] {' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-'},
                new [] {' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|'},
                new [] {' ', ' ', ' ', ' ', ' ', '-', '-', '-', '-', '-'}
            });
        }

        public void Assert(HorizontalAlignment horizontalAlignment, char[][] expected)
        {
            var main = new DockPanel()
            {
                Size = new Size(10, 10)
            };
            var header = new DockChild()
            {
                Element = new DockPanel {
                    Border              = new Thickness(1),
                    HorizontalAlignment = horizontalAlignment,
                    Size                = new Size(5, 5)
                },
                Dock = Dock.Bottom,
                Percent = 30
            };

            var content = new DockChild()
            {
                Element = new DockPanel {
                    Border = new Thickness(1)
                },
                Dock = Dock.Fill
            };

            main.Add(header);
            main.Add(content);

            var cells = Render(main.Size, main);

            AssertCellsAreEquivelant(expected, cells);
        }

    }

    [TestClass]
    public class DockPanelLeftTests : TestBase
    {
        [TestMethod]
        public void DockLeftStretch()
        {
            Assert(VerticalAlignment.Stretch, new[]
                   {
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                   });
        }

        [TestMethod]
        public void DockLeftUnknown()
        {
            Assert(VerticalAlignment.Unknown, new[]
                   {
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                   });
        }

        [TestMethod]
        public void DockLeftTop()
        {
            Assert(VerticalAlignment.Top, new[]
                   {
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-'},
                   });
        }

        [TestMethod]
        public void DockTopCenter()
        {
            Assert(VerticalAlignment.Center, new[]
                   {
                       new[] {' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-'},
                   });
        }

        [TestMethod]
        public void DockLeftBottom()
        {
            Assert(VerticalAlignment.Bottom, new[]
                   {
                       new[] {' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'|', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                       new[] {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                   });
        }

        public void Assert(VerticalAlignment verticalAlignment, char[][] expected)
        {
            var main = new DockPanel()
            {
                Size = new Size(10, 10)
            };
            var header = new DockChild()
            {
                Element = new DockPanel
                {
                    Border = new Thickness(1),
                    VerticalAlignment = verticalAlignment,
                    Size = new Size(5, 5)
                },
                Dock = Dock.Left,
                Percent = 30
            };

            var content = new DockChild()
            {
                Element = new DockPanel
                {
                    Border = new Thickness(1)
                },
                Dock = Dock.Fill
            };

            main.Add(header);
            main.Add(content);

            var cells = Render(main.Size, main);

            AssertCellsAreEquivelant(expected, cells);
        }
    }
}

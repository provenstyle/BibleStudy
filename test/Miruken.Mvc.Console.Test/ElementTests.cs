namespace Miruken.Mvc.Console.Test
{
    using Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ElementTests : TestBase
    {
        private const string alphaString    = "aaaaaa";

        [TestMethod]
        public void CreatesBorder()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'-', '-', '-'},
                new [] {'|', 'a', '|'},
                new [] {'-', '-', '-'},
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderLeft()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1, 0, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'|', 'a', 'a'},
                new [] {'|', 'a', 'a'},
                new [] {'|', 'a', 'a'},
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderLeftWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1, 0, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new[] {'*', '*', '*', '*'},
                new[] {'*', '|', 'a', 'a'},
                new[] {'*', '|', 'a', 'a'},
                new[] {'*', '|', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderRight()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 1, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'a', 'a', '|'},
                new [] {'a', 'a', '|'},
                new [] {'a', 'a', '|'},
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderRightWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 1, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', 'a', 'a', '|'},
                new [] {'*', 'a', 'a', '|'},
                new [] {'*', 'a', 'a', '|'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderTop()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 1, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'-', '-', '-'},
                new [] {'a', 'a', 'a'},
                new [] {'a', 'a', 'a'},
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderTopWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 1, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', '-', '-', '-'},
                new [] {'*', 'a', 'a', 'a'},
                new [] {'*', 'a', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderBottom()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 0, 1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'a', 'a', 'a'},
                new [] {'a', 'a', 'a'},
                new [] {'-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBorderBottomWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 0, 1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new[] {'*', '*', '*', '*'},
                new[] {'*', 'a', 'a', 'a'},
                new[] {'*', 'a', 'a', 'a'},
                new[] {'*', '-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void WhenWidthOrHeightIsLessThanThreeDoesNotCreateBorder()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(2, 2), buffer);
            char[][] expected =
            {
                new[] {'a', 'a'},
                new[] {'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesLeftPadding()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(1, 0, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            char[][] expected =
            {
                new [] {' ', 'a', 'a'},
                new [] {' ', 'a', 'a'},
                new [] {' ', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesLeftPaddingWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(1, 0, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', ' ', 'a', 'a'},
                new [] {'*', ' ', 'a', 'a'},
                new [] {'*', ' ', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesRightPadding()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 0, 1, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'a', 'a', ' '},
                new [] {'a', 'a', ' '},
                new [] {'a', 'a', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesRightPaddingWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 0, 1, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', 'a', 'a', ' '},
                new [] {'*', 'a', 'a', ' '},
                new [] {'*', 'a', 'a', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesTopPadding()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 1, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {' ', ' ', ' '},
                new [] {'a', 'a', 'a'},
                new [] {'a', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesTopPaddingWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 1, 0, 0)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', ' ', ' ', ' '},
                new [] {'*', 'a', 'a', 'a'},
                new [] {'*', 'a', 'a', 'a'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBottomPadding()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 0, 0, 1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

            char[][] expected =
            {
                new [] {'a', 'a', 'a'},
                new [] {'a', 'a', 'a'},
                new [] {' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesBottomPaddingWithPoint()
        {
            var buffer = new OutputBuffer
            {
                Padding = new Thickness(0, 0, 0, 1)
            }
            .WriteLine(alphaString)
            .WriteLine(alphaString)
            .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1,1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*'},
                new [] {'*', 'a', 'a', 'a'},
                new [] {'*', 'a', 'a', 'a'},
                new [] {'*', ' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesContent()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1)
            }
            .WriteLine("abcd")
            .WriteLine("efgh");

            var cells = Render(new Size(4, 4), buffer);

            char[][] expected =
            {
                new [] {'-', '-', '-', '-'},
                new [] {'|', 'a', 'b', '|'},
                new [] {'|', 'e', 'f', '|'},
                new [] {'-', '-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesMarginBorderPaddingAndContentAndRespectsPoint()
        {
            var buffer = new OutputBuffer
            {
                Border  = new Thickness(1),
                Padding = new Thickness(1),
                Margin  = new Thickness(1)
            }
            .WriteLine("abcd")
            .WriteLine("efgh");

            var cells = Render(new Size(9, 9), buffer, new Point(1, 1));

            char[][] expected =
            {
                new[] {'*', '*', '*', '*', '*', '*', '*', '*', '*'},
                new[] {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new[] {'*', ' ', '-', '-', '-', '-', '-', '-', ' '},
                new[] {'*', ' ', '|', ' ', ' ', ' ', ' ', '|', ' '},
                new[] {'*', ' ', '|', ' ', 'a', 'b', ' ', '|', ' '},
                new[] {'*', ' ', '|', ' ', 'e', 'f', ' ', '|', ' '},
                new[] {'*', ' ', '|', ' ', ' ', ' ', ' ', '|', ' '},
                new[] {'*', ' ', '-', '-', '-', '-', '-', '-', ' '},
                new[] {'*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void RespectsPointLocation()
        {
            var buffer = new OutputBuffer
            {
                Border  = new Thickness(1),
                Padding = new Thickness(1)
            }
            .WriteLine("abcde")
            .WriteLine("fghi");

            var cells = Render(new Size(8, 8), buffer, new Point(1, 1));

            char[][] expected =
            {
                new [] {'*', '*', '*', '*', '*', '*', '*', '*'},
                new [] {'*', '-', '-', '-', '-', '-', '-', '-'},
                new [] {'*', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'*', '|', ' ', 'a', 'b', 'c', ' ', '|'},
                new [] {'*', '|', ' ', 'f', 'g', 'h', ' ', '|'},
                new [] {'*', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'*', '|', ' ', ' ', ' ', ' ', ' ', '|'},
                new [] {'*', '-', '-', '-', '-', '-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesMarginLeft()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(1, 0, 0, 0),
                Margin = new Thickness(1, 0, 0, 0)
            };

            var cells = Render(new Size(4, 4), buffer);

            char[][] expected =
            {
                new[] {' ', '|', ' ', ' '},
                new[] {' ', '|', ' ', ' '},
                new[] {' ', '|', ' ', ' '},
                new[] {' ', '|', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesMarginRight()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 1, 0),
                Margin = new Thickness(0, 0, 1, 0)
            };

            var cells = Render(new Size(4, 4), buffer);

            char[][] expected =
            {
                new[] {' ', ' ', '|', ' '},
                new[] {' ', ' ', '|', ' '},
                new[] {' ', ' ', '|', ' '},
                new[] {' ', ' ', '|', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesMarginTop()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 1, 0, 0),
                Margin = new Thickness(0, 1, 0, 0)
            };

            var cells = Render(new Size(4, 4), buffer);

            char[][] expected =
            {
                new[] {' ', ' ', ' ', ' '},
                new[] {'-', '-', '-', '-'},
                new[] {' ', ' ', ' ', ' '},
                new[] {' ', ' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void CreatesMarginBottom()
        {
            var buffer = new OutputBuffer
            {
                Border = new Thickness(0, 0, 0, 1),
                Margin = new Thickness(0, 0, 0, 1)
            };

            var cells = Render(new Size(4, 4), buffer);

            char[][] expected =
            {
                new[] {' ', ' ', ' ', ' '},
                new[] {' ', ' ', ' ', ' '},
                new[] {'-', '-', '-', '-'},
                new[] {' ', ' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void MultipleBorders()
        {
            var buffer = new OutputBuffer
                {
                    Border = new Thickness(2)
                }
                .WriteLine("ab")
                .WriteLine("cd");

            var cells = Render(new Size(6, 6), buffer);

            char[][] expected =
            {
                new[] {'-', '-', '-', '-', '-', '-'},
                new[] {'-', '-', '-', '-', '-', '-'},
                new[] {'|', '|', 'a', 'b', '|', '|'},
                new[] {'|', '|', 'c', 'd', '|', '|'},
                new[] {'-', '-', '-', '-', '-', '-'},
                new[] {'-', '-', '-', '-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void SingleBorderMultiplePadding()
        {
            var buffer = new OutputBuffer
                {
                    Border  = new Thickness(1),
                    Padding = new Thickness(2)
                }
                .WriteLine("ab")
                .WriteLine("cd");

            var cells = Render(new Size(8, 8), buffer);

            char[][] expected =
            {
                new[] {'-', '-', '-', '-', '-', '-', '-', '-'},
                new[] {'|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new[] {'|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new[] {'|', ' ', ' ', 'a', 'b', ' ', ' ', '|'},
                new[] {'|', ' ', ' ', 'c', 'd', ' ', ' ', '|'},
                new[] {'|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new[] {'|', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                new[] {'-', '-', '-', '-', '-', '-', '-', '-'}
            };

            AssertCellsAreEquivelant(expected, cells);
        }

        [TestMethod]
        public void MultipleMarginBorderPadding()
        {
            var buffer = new OutputBuffer
                {
                    Margin  = new Thickness(2),
                    Border  = new Thickness(2),
                    Padding = new Thickness(2)
                }
                .WriteLine("ab")
                .WriteLine("cd");

            var cells = Render(new Size(14, 14), buffer);

            char[][] expected =
            {
                new[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new[] {' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new[] {' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', 'a', 'b', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', 'c', 'd', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' '},
                new[] {' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new[] {' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ', ' '},
                new[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                new[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

            AssertCellsAreEquivelant(expected, cells);
        }
    }
}

namespace Miruken.Mvc.Console.Test
{
    using System;
    using Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ElementTests
    {
        private const char   spaceCharacter = ' ';
        private const char   alphaCharacter = 'a';
        private const string alphaString    = "aaaaaa";

        [TestMethod]
        public void CreatesBorder()
        {
            var cells = new Control()
                .Border(1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            //TopRow
            Assert.AreEqual('-', cells[0][0]);
            Assert.AreEqual('-', cells[0][1]);
            Assert.AreEqual('-', cells[0][2]);

            //BottomRow
            Assert.AreEqual('-', cells[2][0]);
            Assert.AreEqual('-', cells[2][1]);
            Assert.AreEqual('-', cells[2][2]);

            //LeftColumn
            Assert.AreEqual('-', cells[0][0]);
            Assert.AreEqual('|', cells[1][0]);
            Assert.AreEqual('-', cells[2][0]);

            //RightColumn
            Assert.AreEqual('-', cells[0][2]);
            Assert.AreEqual('|', cells[1][2]);
            Assert.AreEqual('-', cells[2][2]);

            //Content
            Assert.AreEqual(alphaCharacter, cells[1][1]);
        }

        [TestMethod]
        public void CreatesBorderLeft()
        {
            var cells = new Control()
                .Border(1, 0, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            //LeftColumn
            Assert.AreEqual('|', cells[0][0]);
            Assert.AreEqual('|', cells[1][0]);
            Assert.AreEqual('|', cells[2][0]);

            //RightColumn
            Assert.AreEqual(alphaCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesBorderRight()
        {
            var cells = new Control()
                .Border(0, 0, 1, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            //LeftColumn
            Assert.AreEqual(alphaCharacter, cells[0][0]);
            Assert.AreEqual(alphaCharacter, cells[1][0]);
            Assert.AreEqual(alphaCharacter, cells[2][0]);

            //RightColumn
            Assert.AreEqual('|', cells[0][2]);
            Assert.AreEqual('|', cells[1][2]);
            Assert.AreEqual('|', cells[2][2]);
        }

        [TestMethod]
        public void CreatesBorderTop()
        {
            var cells = new Control()
                .Border(0, 1, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            //TopRow
            Assert.AreEqual('-', cells[0][0]);
            Assert.AreEqual('-', cells[0][1]);
            Assert.AreEqual('-', cells[0][2]);

            //BottomRow
            Assert.AreEqual(alphaCharacter, cells[2][0]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesBorderBottom()
        {
            var cells = new Control()
                .Border(0, 0, 0, 1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            //TopRow
            Assert.AreEqual(alphaCharacter, cells[0][0]);
            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[0][2]);

            //BottomRow
            Assert.AreEqual('-', cells[2][0]);
            Assert.AreEqual('-', cells[2][1]);
            Assert.AreEqual('-', cells[2][2]);
        }

        [TestMethod]
        public void WhenWidthOrHeightIsLessThanThreeDoesNotCreateBorder()
        {
            var cells = new Control()
                .Border(1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(2,2);

            Console.WriteLine(cells);

            for (var x = 0; x < 2; x++)
            {
                for (var y = 0; y < 2; y++)
                {
                    Assert.AreEqual(alphaCharacter, cells[y][x]);
                }
            }
        }

        [TestMethod]
        public void CreatesLeftPadding()
        {
            var cells = new Control()
                .Padding(1, 0, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
        }

        [TestMethod]
        public void CreatesRightPadding()
        {
            var cells = new Control()
                .Padding(0, 0, 1, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells.ToString());

            Assert.AreEqual(alphaCharacter, cells[0][0]);
            Assert.AreEqual(alphaCharacter, cells[1][0]);
            Assert.AreEqual(alphaCharacter, cells[2][0]);
            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(spaceCharacter, cells[1][2]);
            Assert.AreEqual(spaceCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesTopPadding()
        {
            var cells = new Control()
                .Padding(0, 1, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(alphaCharacter, cells[1][0]);
            Assert.AreEqual(alphaCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesBottomPadding()
        {
            var cells = new Control()
                .Padding(0, 0, 0, 1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(cells);

            Assert.AreEqual(alphaCharacter, cells[0][0]);
            Assert.AreEqual(alphaCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(spaceCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(spaceCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesContent()
        {
            var cells = new Control()
                .Border(1)
                .WriteLine("abcd")
                .WriteLine("efgh")
                .Render(4, 4);

            Console.WriteLine(cells);

            //Content
            Assert.AreEqual('a', cells[1][1]);
            Assert.AreEqual('b', cells[1][2]);
            Assert.AreEqual('e', cells[2][1]);
            Assert.AreEqual('f', cells[2][2]);
        }

        [TestMethod]
        public void CreatesBorderPaddingAndContent()
        {
            var cells = new Control()
                .Border(1)
                .Padding(1)
                .WriteLine("abcd")
                .WriteLine("efgh")
                .Render(6, 6);

            Console.WriteLine(cells.ToString());

            //topborder
            Assert.AreEqual('-', cells[0][0]);
            Assert.AreEqual('-', cells[0][1]);
            Assert.AreEqual('-', cells[0][2]);
            Assert.AreEqual('-', cells[0][3]);
            Assert.AreEqual('-', cells[0][4]);
            Assert.AreEqual('-', cells[0][5]);
            //bottomborder
            Assert.AreEqual('-', cells[5][0]);
            Assert.AreEqual('-', cells[5][1]);
            Assert.AreEqual('-', cells[5][2]);
            Assert.AreEqual('-', cells[5][3]);
            Assert.AreEqual('-', cells[5][4]);
            Assert.AreEqual('-', cells[5][5]);
            //leftborder
            Assert.AreEqual('-', cells[0][0]);
            Assert.AreEqual('|', cells[1][0]);
            Assert.AreEqual('|', cells[2][0]);
            Assert.AreEqual('|', cells[3][0]);
            Assert.AreEqual('|', cells[4][0]);
            Assert.AreEqual('-', cells[5][0]);
            //rightborder
            Assert.AreEqual('-', cells[0][5]);
            Assert.AreEqual('|', cells[1][5]);
            Assert.AreEqual('|', cells[2][5]);
            Assert.AreEqual('|', cells[3][5]);
            Assert.AreEqual('|', cells[4][5]);
            Assert.AreEqual('-', cells[5][5]);
            //toppadding
            Assert.AreEqual(spaceCharacter, cells[1][1]);
            Assert.AreEqual(spaceCharacter, cells[1][2]);
            Assert.AreEqual(spaceCharacter, cells[1][3]);
            Assert.AreEqual(spaceCharacter, cells[1][4]);
            //bottompadding
            Assert.AreEqual(spaceCharacter, cells[4][1]);
            Assert.AreEqual(spaceCharacter, cells[4][2]);
            Assert.AreEqual(spaceCharacter, cells[4][3]);
            Assert.AreEqual(spaceCharacter, cells[4][4]);
            //leftpadding
            Assert.AreEqual(spaceCharacter, cells[1][1]);
            Assert.AreEqual(spaceCharacter, cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[3][1]);
            Assert.AreEqual(spaceCharacter, cells[4][1]);
            //rightpadding
            Assert.AreEqual(spaceCharacter, cells[1][4]);
            Assert.AreEqual(spaceCharacter, cells[2][4]);
            Assert.AreEqual(spaceCharacter, cells[3][4]);
            Assert.AreEqual(spaceCharacter, cells[4][4]);
            //Content
            Assert.AreEqual('a', cells[2][2]);
            Assert.AreEqual('b', cells[2][3]);
            Assert.AreEqual('e', cells[3][2]);
            Assert.AreEqual('f', cells[3][3]);
        }

    }
}

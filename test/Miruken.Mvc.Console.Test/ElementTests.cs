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
            var element = new Element()
                .Border(1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            //TopRow
            Assert.AreEqual('-', element[0][0]);
            Assert.AreEqual('-', element[0][1]);
            Assert.AreEqual('-', element[0][2]);

            //BottomRow
            Assert.AreEqual('-', element[2][0]);
            Assert.AreEqual('-', element[2][1]);
            Assert.AreEqual('-', element[2][2]);

            //LeftColumn
            Assert.AreEqual('-', element[0][0]);
            Assert.AreEqual('|', element[1][0]);
            Assert.AreEqual('-', element[2][0]);

            //RightColumn
            Assert.AreEqual('-', element[0][2]);
            Assert.AreEqual('|', element[1][2]);
            Assert.AreEqual('-', element[2][2]);

            //Content
            Assert.AreEqual(alphaCharacter, element[1][1]);
        }

        [TestMethod]
        public void CreatesBorderLeft()
        {
            var element = new Element()
                .Border(1, 0, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            //LeftColumn
            Assert.AreEqual('|', element[0][0]);
            Assert.AreEqual('|', element[1][0]);
            Assert.AreEqual('|', element[2][0]);

            //RightColumn
            Assert.AreEqual(alphaCharacter, element[0][2]);
            Assert.AreEqual(alphaCharacter, element[1][2]);
            Assert.AreEqual(alphaCharacter, element[2][2]);
        }

        [TestMethod]
        public void CreatesBorderRight()
        {
            var element = new Element()
                .Border(0, 0, 1, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            //LeftColumn
            Assert.AreEqual(alphaCharacter, element[0][0]);
            Assert.AreEqual(alphaCharacter, element[1][0]);
            Assert.AreEqual(alphaCharacter, element[2][0]);

            //RightColumn
            Assert.AreEqual('|', element[0][2]);
            Assert.AreEqual('|', element[1][2]);
            Assert.AreEqual('|', element[2][2]);
        }

        [TestMethod]
        public void CreatesBorderTop()
        {
            var element = new Element()
                .Border(0, 1, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            //TopRow
            Assert.AreEqual('-', element[0][0]);
            Assert.AreEqual('-', element[0][1]);
            Assert.AreEqual('-', element[0][2]);

            //BottomRow
            Assert.AreEqual(alphaCharacter, element[2][0]);
            Assert.AreEqual(alphaCharacter, element[2][1]);
            Assert.AreEqual(alphaCharacter, element[2][2]);
        }

        [TestMethod]
        public void CreatesBorderBottom()
        {
            var element = new Element()
                .Border(0, 0, 0, 1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            //TopRow
            Assert.AreEqual(alphaCharacter, element[0][0]);
            Assert.AreEqual(alphaCharacter, element[0][1]);
            Assert.AreEqual(alphaCharacter, element[0][2]);

            //BottomRow
            Assert.AreEqual('-', element[2][0]);
            Assert.AreEqual('-', element[2][1]);
            Assert.AreEqual('-', element[2][2]);
        }

        [TestMethod]
        public void WhenWidthOrHeightIsLessThanThreeDoesNotCreateBorder()
        {
            var element = new Element()
                .Border(1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(2,2);

            Console.WriteLine(Cells.Render(element));

            for (var x = 0; x < 2; x++)
            {
                for (var y = 0; y < 2; y++)
                {
                    Assert.AreEqual(alphaCharacter, element[y][x]);
                }
            }
        }

        [TestMethod]
        public void CreatesLeftPadding()
        {
            var element = new Element()
                .Padding(1, 0, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            Assert.AreEqual(spaceCharacter, element[0][0]);
            Assert.AreEqual(spaceCharacter, element[1][0]);
            Assert.AreEqual(spaceCharacter, element[2][0]);
            Assert.AreEqual(alphaCharacter, element[0][1]);
            Assert.AreEqual(alphaCharacter, element[1][1]);
            Assert.AreEqual(alphaCharacter, element[2][1]);
        }

        [TestMethod]
        public void CreatesRightPadding()
        {
            var element = new Element()
                .Padding(0, 0, 1, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            Assert.AreEqual(alphaCharacter, element[0][0]);
            Assert.AreEqual(alphaCharacter, element[1][0]);
            Assert.AreEqual(alphaCharacter, element[2][0]);
            Assert.AreEqual(alphaCharacter, element[0][1]);
            Assert.AreEqual(alphaCharacter, element[1][1]);
            Assert.AreEqual(alphaCharacter, element[2][1]);
            Assert.AreEqual(spaceCharacter, element[0][2]);
            Assert.AreEqual(spaceCharacter, element[1][2]);
            Assert.AreEqual(spaceCharacter, element[2][2]);
        }

        [TestMethod]
        public void CreatesTopPadding()
        {
            var element = new Element()
                .Padding(0, 1, 0, 0)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            Assert.AreEqual(spaceCharacter, element[0][0]);
            Assert.AreEqual(alphaCharacter, element[1][0]);
            Assert.AreEqual(alphaCharacter, element[2][0]);
            Assert.AreEqual(spaceCharacter, element[0][1]);
            Assert.AreEqual(alphaCharacter, element[1][1]);
            Assert.AreEqual(alphaCharacter, element[2][1]);
            Assert.AreEqual(spaceCharacter, element[0][2]);
            Assert.AreEqual(alphaCharacter, element[1][2]);
            Assert.AreEqual(alphaCharacter, element[2][2]);
        }

        [TestMethod]
        public void CreatesBottomPadding()
        {
            var element = new Element()
                .Padding(0, 0, 0, 1)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .Render(3, 3);

            Console.WriteLine(Cells.Render(element));

            Assert.AreEqual(alphaCharacter, element[0][0]);
            Assert.AreEqual(alphaCharacter, element[1][0]);
            Assert.AreEqual(spaceCharacter, element[2][0]);
            Assert.AreEqual(alphaCharacter, element[0][1]);
            Assert.AreEqual(alphaCharacter, element[1][1]);
            Assert.AreEqual(spaceCharacter, element[2][1]);
            Assert.AreEqual(alphaCharacter, element[0][2]);
            Assert.AreEqual(alphaCharacter, element[1][2]);
            Assert.AreEqual(spaceCharacter, element[2][2]);
        }

        [TestMethod]
        public void CreatesContent()
        {
            var element = new Element()
                .Border(1)
                .WriteLine("abcd")
                .WriteLine("efgh")
                .Render(4, 4);

            Console.WriteLine(Cells.Render(element));

            //Content
            Assert.AreEqual('a', element[1][1]);
            Assert.AreEqual('b', element[1][2]);
            Assert.AreEqual('e', element[2][1]);
            Assert.AreEqual('f', element[2][2]);
        }

        [TestMethod]
        public void CreatesBorderPaddingAndContent()
        {
            var element = new Element()
                .Border(1)
                .Padding(1)
                .WriteLine("abcd")
                .WriteLine("efgh")
                .Render(6, 6);

            Console.WriteLine(Cells.Render(element));

            //topborder
            Assert.AreEqual('-', element[0][0]);
            Assert.AreEqual('-', element[0][1]);
            Assert.AreEqual('-', element[0][2]);
            Assert.AreEqual('-', element[0][3]);
            Assert.AreEqual('-', element[0][4]);
            Assert.AreEqual('-', element[0][5]);
            //bottomborder
            Assert.AreEqual('-', element[5][0]);
            Assert.AreEqual('-', element[5][1]);
            Assert.AreEqual('-', element[5][2]);
            Assert.AreEqual('-', element[5][3]);
            Assert.AreEqual('-', element[5][4]);
            Assert.AreEqual('-', element[5][5]);
            //leftborder
            Assert.AreEqual('-', element[0][0]);
            Assert.AreEqual('|', element[1][0]);
            Assert.AreEqual('|', element[2][0]);
            Assert.AreEqual('|', element[3][0]);
            Assert.AreEqual('|', element[4][0]);
            Assert.AreEqual('-', element[5][0]);
            //rightborder
            Assert.AreEqual('-', element[0][5]);
            Assert.AreEqual('|', element[1][5]);
            Assert.AreEqual('|', element[2][5]);
            Assert.AreEqual('|', element[3][5]);
            Assert.AreEqual('|', element[4][5]);
            Assert.AreEqual('-', element[5][5]);
            //toppadding
            Assert.AreEqual(spaceCharacter, element[1][1]);
            Assert.AreEqual(spaceCharacter, element[1][2]);
            Assert.AreEqual(spaceCharacter, element[1][3]);
            Assert.AreEqual(spaceCharacter, element[1][4]);
            //bottompadding
            Assert.AreEqual(spaceCharacter, element[4][1]);
            Assert.AreEqual(spaceCharacter, element[4][2]);
            Assert.AreEqual(spaceCharacter, element[4][3]);
            Assert.AreEqual(spaceCharacter, element[4][4]);
            //leftpadding
            Assert.AreEqual(spaceCharacter, element[1][1]);
            Assert.AreEqual(spaceCharacter, element[2][1]);
            Assert.AreEqual(spaceCharacter, element[3][1]);
            Assert.AreEqual(spaceCharacter, element[4][1]);
            //rightpadding
            Assert.AreEqual(spaceCharacter, element[1][4]);
            Assert.AreEqual(spaceCharacter, element[2][4]);
            Assert.AreEqual(spaceCharacter, element[3][4]);
            Assert.AreEqual(spaceCharacter, element[4][4]);
            //Content
            Assert.AreEqual('a', element[2][2]);
            Assert.AreEqual('b', element[2][3]);
            Assert.AreEqual('e', element[3][2]);
            Assert.AreEqual('f', element[3][3]);
        }

    }
}

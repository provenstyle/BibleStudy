namespace Miruken.Mvc.Console.Test
{
    using System;
    using Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ElementTests : TestBase
    {
        private const char   spaceCharacter = ' ';
        private const char   alphaCharacter = 'a';
        private const string alphaString    = "aaaaaa";

        [TestMethod]
        public void CreatesBorder()
        {
            var buffer = new OutputBuffer();
            buffer.Border(1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);

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
            var buffer = new OutputBuffer();
            buffer.Border(1, 0, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            //LeftColumn
            Assert.AreEqual('|', cells[0][0]);
            Assert.AreEqual('|', cells[1][0]);
            Assert.AreEqual('|', cells[2][0]);

            //MiddleColumn
            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);

            //RightColumn
            Assert.AreEqual(alphaCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesBorderLeftWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Border(1, 0, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            //LeftColumn
            Assert.AreEqual(Cells.SpaceChar, cells[0][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[2][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[3][0]);

            //MiddleColumn
            Assert.AreEqual(Cells.SpaceChar, cells[0][1]);
            Assert.AreEqual('|',             cells[1][1]);
            Assert.AreEqual('|',             cells[2][1]);
            Assert.AreEqual('|',             cells[3][1]);

            //RightColumn
            Assert.AreEqual(Cells.SpaceChar, cells[0][2]);
            Assert.AreEqual(alphaCharacter,  cells[1][2]);
            Assert.AreEqual(alphaCharacter,  cells[2][2]);
            Assert.AreEqual(alphaCharacter,  cells[3][2]);
        }

        [TestMethod]
        public void CreatesBorderRight()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 0, 1, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesBorderRightWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 0, 1, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            //Column0
            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[3][0]);

            //Column1
            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[3][1]);

            //Column2
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(alphaCharacter, cells[3][2]);

            //Column3
            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual('|',            cells[1][3]);
            Assert.AreEqual('|',            cells[2][3]);
            Assert.AreEqual('|',            cells[3][3]);
        }

        [TestMethod]
        public void CreatesBorderTop()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 1, 0, 0);
            buffer.WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesBorderTopWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 1, 0, 0);
            buffer.WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            //Row0
            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(spaceCharacter, cells[0][3]);

            //Row1
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual('-',            cells[1][1]);
            Assert.AreEqual('-',            cells[1][2]);
            Assert.AreEqual('-',            cells[1][3]);

            //Row2
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(alphaCharacter, cells[2][3]);

            //Row3
            Assert.AreEqual(spaceCharacter, cells[3][0]);
            Assert.AreEqual(alphaCharacter, cells[3][1]);
            Assert.AreEqual(alphaCharacter, cells[3][2]);
            Assert.AreEqual(alphaCharacter, cells[3][3]);
        }

        [TestMethod]
        public void CreatesBorderBottom()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 0, 0, 1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesBorderBottomWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Border(0, 0, 0, 1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            //Row0
            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(spaceCharacter, cells[0][3]);

            //Row1
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[1][3]);

            //BottomRow
            Assert.AreEqual(spaceCharacter, cells[3][0]);
            Assert.AreEqual('-',            cells[3][1]);
            Assert.AreEqual('-',            cells[3][2]);
            Assert.AreEqual('-',            cells[3][3]);
        }

        [TestMethod]
        public void WhenWidthOrHeightIsLessThanThreeDoesNotCreateBorder()
        {
            var buffer = new OutputBuffer();
            buffer.Border(1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(2, 2), buffer);
            buffer.Render(cells);

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
            var buffer = new OutputBuffer();
            buffer.Padding(1, 0, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);

            Assert.AreEqual(alphaCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);

            Assert.AreEqual(alphaCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
        }

        [TestMethod]
        public void CreatesLeftPaddingWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(1, 0, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[3][0]);

            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(spaceCharacter, cells[1][1]);
            Assert.AreEqual(spaceCharacter, cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[3][1]);

            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(alphaCharacter, cells[3][2]);

            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual(alphaCharacter, cells[1][3]);
            Assert.AreEqual(alphaCharacter, cells[2][3]);
            Assert.AreEqual(alphaCharacter, cells[3][3]);
        }

        [TestMethod]
        public void CreatesRightPadding()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 0, 1, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesRightPaddingWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 0, 1, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[3][0]);

            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[3][1]);

            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(alphaCharacter, cells[3][2]);

            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual(spaceCharacter, cells[1][3]);
            Assert.AreEqual(spaceCharacter, cells[2][3]);
            Assert.AreEqual(spaceCharacter, cells[3][3]);
        }

        [TestMethod]
        public void CreatesTopPadding()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 1, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesTopPaddingWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 1, 0, 0);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[3][0]);

            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(spaceCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(alphaCharacter, cells[3][1]);

            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(spaceCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(alphaCharacter, cells[3][2]);

            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual(spaceCharacter, cells[1][3]);
            Assert.AreEqual(alphaCharacter, cells[2][3]);
            Assert.AreEqual(alphaCharacter, cells[3][3]);
        }

        [TestMethod]
        public void CreatesBottomPadding()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 0, 0, 1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(3, 3), buffer);
            buffer.Render(cells);

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
        public void CreatesBottomPaddingWithPoint()
        {
            var buffer = new OutputBuffer();
            buffer.Padding(0, 0, 0, 1);
            buffer
                .WriteLine(alphaString)
                .WriteLine(alphaString)
                .WriteLine(alphaString);

            var cells = Render(new Size(4, 4), buffer, new Point(1,1));
            buffer.Render(cells);

            Console.WriteLine(cells);

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual(spaceCharacter, cells[3][0]);

            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(alphaCharacter, cells[1][1]);
            Assert.AreEqual(alphaCharacter, cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[3][1]);

            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(alphaCharacter, cells[1][2]);
            Assert.AreEqual(alphaCharacter, cells[2][2]);
            Assert.AreEqual(spaceCharacter, cells[3][2]);

            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual(alphaCharacter, cells[1][3]);
            Assert.AreEqual(alphaCharacter, cells[2][3]);
            Assert.AreEqual(spaceCharacter, cells[3][3]);
        }

        [TestMethod]
        public void CreatesContent()
        {
            var buffer = new OutputBuffer();
            buffer.Border(1);
            buffer
                .WriteLine("abcd")
                .WriteLine("efgh");

            var cells = Render(new Size(4, 4), buffer);
            buffer.Render(cells);

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
            var buffer = new OutputBuffer();
            buffer
                .Border(1)
                .Padding(1);
            buffer
                .WriteLine("abcd")
                .WriteLine("efgh");

            var cells = Render(new Size(6, 6), buffer);
            buffer.Render(cells);

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

        [TestMethod]
        public void RespectsPointLocation()
        {
            var buffer = new OutputBuffer();
            buffer.Point = new Point(1, 2);
            buffer
                .Border(1)
                .Padding(1);
            buffer
                .WriteLine("abcde")
                .WriteLine("fghi");

            var cells = Render(new Size(8, 8), buffer, new Point(1, 1));
            buffer.Render(cells);

            Console.WriteLine(cells.ToString());

            Assert.AreEqual(spaceCharacter, cells[0][0]);
            Assert.AreEqual(spaceCharacter, cells[0][1]);
            Assert.AreEqual(spaceCharacter, cells[0][2]);
            Assert.AreEqual(spaceCharacter, cells[0][3]);
            Assert.AreEqual(spaceCharacter, cells[0][4]);
            Assert.AreEqual(spaceCharacter, cells[0][5]);
            Assert.AreEqual(spaceCharacter, cells[0][6]);
            Assert.AreEqual(spaceCharacter, cells[0][7]);

            Assert.AreEqual(spaceCharacter, cells[1][0]);
            Assert.AreEqual('-',            cells[1][1]);
            Assert.AreEqual('-',            cells[1][2]);
            Assert.AreEqual('-',            cells[1][3]);
            Assert.AreEqual('-',            cells[1][4]);
            Assert.AreEqual('-',            cells[1][5]);
            Assert.AreEqual('-',            cells[1][6]);
            Assert.AreEqual('-',            cells[1][7]);

            Assert.AreEqual(spaceCharacter, cells[2][0]);
            Assert.AreEqual('|',            cells[2][1]);
            Assert.AreEqual(spaceCharacter, cells[2][2]);
            Assert.AreEqual(spaceCharacter, cells[2][3]);
            Assert.AreEqual(spaceCharacter, cells[2][4]);
            Assert.AreEqual(spaceCharacter, cells[2][5]);
            Assert.AreEqual(spaceCharacter, cells[2][6]);
            Assert.AreEqual('|',            cells[2][7]);

            Assert.AreEqual(spaceCharacter, cells[3][0]);
            Assert.AreEqual('|',            cells[3][1]);
            Assert.AreEqual(spaceCharacter, cells[3][2]);
            Assert.AreEqual('a',            cells[3][3]);
            Assert.AreEqual('b',            cells[3][4]);
            Assert.AreEqual('c',            cells[3][5]);
            Assert.AreEqual(spaceCharacter, cells[3][6]);
            Assert.AreEqual('|',            cells[3][7]);

            Assert.AreEqual(spaceCharacter, cells[4][0]);
            Assert.AreEqual('|',            cells[4][1]);
            Assert.AreEqual(spaceCharacter, cells[4][2]);
            Assert.AreEqual('f',            cells[4][3]);
            Assert.AreEqual('g',            cells[4][4]);
            Assert.AreEqual('h',            cells[4][5]);
            Assert.AreEqual(spaceCharacter, cells[4][6]);
            Assert.AreEqual('|',            cells[4][7]);

            Assert.AreEqual(spaceCharacter, cells[5][0]);
            Assert.AreEqual('|',            cells[5][1]);
            Assert.AreEqual(spaceCharacter, cells[5][2]);
            Assert.AreEqual(spaceCharacter, cells[5][3]);
            Assert.AreEqual(spaceCharacter, cells[5][4]);
            Assert.AreEqual(spaceCharacter, cells[5][5]);
            Assert.AreEqual(spaceCharacter, cells[5][6]);
            Assert.AreEqual('|',            cells[5][7]);

            Assert.AreEqual(spaceCharacter, cells[6][0]);
            Assert.AreEqual('|',            cells[6][1]);
            Assert.AreEqual(spaceCharacter, cells[6][2]);
            Assert.AreEqual(spaceCharacter, cells[6][3]);
            Assert.AreEqual(spaceCharacter, cells[6][4]);
            Assert.AreEqual(spaceCharacter, cells[6][5]);
            Assert.AreEqual(spaceCharacter, cells[6][6]);
            Assert.AreEqual('|',            cells[6][7]);

            Assert.AreEqual(spaceCharacter, cells[7][0]);
            Assert.AreEqual('-',            cells[7][1]);
            Assert.AreEqual('-',            cells[7][2]);
            Assert.AreEqual('-',            cells[7][3]);
            Assert.AreEqual('-',            cells[7][4]);
            Assert.AreEqual('-',            cells[7][5]);
            Assert.AreEqual('-',            cells[7][6]);
            Assert.AreEqual('-',            cells[7][7]);
        }

    }
}

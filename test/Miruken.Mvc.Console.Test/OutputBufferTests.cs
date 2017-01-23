namespace Miruken.Mvc.Console.Test
{
    using System;
    using Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OutputBufferTests : TestBase
    {
        [TestMethod]
        public void WriteLine()
        {
            var cells = Render(new Size(2, 2), new OutputBuffer()
                .WriteLine("abcd")
                .WriteLine("efgh")
                .WriteLine("ijkl"));

            Console.WriteLine(cells);

            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('e', cells[1][0]);
            Assert.AreEqual('f', cells[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsNewLineCharacters()
        {
            var cells = Render(new Size(2, 2), new OutputBuffer()
                .WriteLine("a" + Environment.NewLine + "b" + Environment.NewLine + "c"));

            Console.WriteLine(cells);

            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[1][0]);
        }

        [TestMethod]
        public void Wrap()
        {
            var cells = Render(new Size(2, 2), new OutputBuffer()
                .Wrap("abcdefg"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('c', cells[1][0]);
            Assert.AreEqual('d', cells[1][1]);
        }

        [TestMethod]
        public void WrapEndsWithANewLine()
        {
            var cells = Render(new Size(2, 2), new OutputBuffer()
                .Wrap("a")
                .Wrap("b"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[1][0]);
        }

        [TestMethod]
        public void WrapRespectsNewLineCharacters()
        {
            var cells = Render(new Size(2, 3), new OutputBuffer()
                .Wrap("abc" + Environment.NewLine + "defg"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a',             cells[0][0]);
            Assert.AreEqual('b',             cells[0][1]);
            Assert.AreEqual('c',             cells[1][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][1]);
            Assert.AreEqual('d',             cells[2][0]);
            Assert.AreEqual('e',             cells[2][1]);
        }

        [TestMethod]
        public void WrapRespectsTabCharacters()
        {
            var cells = Render(new Size(12, 3), new OutputBuffer()
                .Wrap("1234567890")
                .Wrap("\ta"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
        }

        [TestMethod]
        public void Write()
        {
            var cells = Render(new Size(2, 2), new OutputBuffer()
                .Write("ab"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a',             cells[0][0]);
            Assert.AreEqual('b',             cells[0][1]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][1]);
        }

        [TestMethod]
        public void WriteRespectsNewLineCharacters()
        {
            var cells = Render(new Size(3, 3), new OutputBuffer()
                .Write("ab" + Environment.NewLine + "cd"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('c', cells[1][0]);
            Assert.AreEqual('d', cells[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsTabCharacters()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void TabConsidersExistingPosition()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdfe")
                .Write("\ta")
                .Write("ghi")
                .Write("\ta"));

            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharactersWithTabSpacesMinusOne()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefgh")
                .Write("\ta"));
            Console.WriteLine(cells.ToString());
            Assert.AreEqual(Cells.SpaceChar, cells[1][7]);
            Assert.AreEqual('a',             cells[1][8]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharacters()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefghi")
                .Write("\ta"));
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('i', cells[1][7]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void WriteRespectsTabCharacters()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta"));
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void WriteWrapsTabCharactersToTheNextLine()
        {
            var cells = Render(new Size(20, 3), new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta\ta"));
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
            Assert.AreEqual('a', cells[2][0]);
        }
    }
}

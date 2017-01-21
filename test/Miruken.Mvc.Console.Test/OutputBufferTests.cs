namespace Miruken.Mvc.Console.Test
{
    using System;
    using Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OutputBufferTests
    {
        [TestMethod]
        public void WriteLine()
        {
            var cells = new OutputBuffer()
                .WriteLine("abcd")
                .WriteLine("efgh")
                .WriteLine("ijkl")
                .Render(2, 2);

            Console.WriteLine(cells);

            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('e', cells[1][0]);
            Assert.AreEqual('f', cells[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsNewLineCharacters()
        {
            var cells = new OutputBuffer()
                .WriteLine("a" + Environment.NewLine + "b" + Environment.NewLine + "c")
                .Render(2, 2);
            Console.WriteLine(cells);
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[1][0]);
        }

        [TestMethod]
        public void Wrap()
        {
            var cells = new OutputBuffer()
                .Wrap("abcdefg")
                .Render(2, 2);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('c', cells[1][0]);
            Assert.AreEqual('d', cells[1][1]);
        }

        [TestMethod]
        public void WrapEndsWithANewLine()
        {
            var cells = new OutputBuffer()
                .Wrap("a")
                .Wrap("b")
                .Render(2, 2);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[1][0]);
        }

        [TestMethod]
        public void WrapRespectsNewLineCharacters()
        {
            var cells = new OutputBuffer()
                .Wrap("abc" + Environment.NewLine + "defg")
                .Render(2, 3);
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
            var cells = new OutputBuffer()
                .Wrap("1234567890")
                .Wrap("\ta")
                .Render(12, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
        }

        [TestMethod]
        public void Write()
        {
            var cells = new OutputBuffer()
                .Write("ab")
                .Render(2, 2);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a',             cells[0][0]);
            Assert.AreEqual('b',             cells[0][1]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][0]);
            Assert.AreEqual(Cells.SpaceChar, cells[1][1]);
        }

        [TestMethod]
        public void WriteRespectsNewLineCharacters()
        {
            var cells = new OutputBuffer()
                .Write("ab" + Environment.NewLine + "cd")
                .Render(3, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('b', cells[0][1]);
            Assert.AreEqual('c', cells[1][0]);
            Assert.AreEqual('d', cells[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsTabCharacters()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void TabConsidersExistingPosition()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdfe")
                .Write("\ta")
                .Write("ghi")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharactersWithTabSpacesMinusOne()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefgh")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual(Cells.SpaceChar, cells[1][7]);
            Assert.AreEqual('a',             cells[1][8]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharacters()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefghi")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('i', cells[1][7]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void WriteRespectsTabCharacters()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
        }

        [TestMethod]
        public void WriteWrapsTabCharactersToTheNextLine()
        {
            var cells = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta\ta")
                .Render(20, 3);
            Console.WriteLine(cells.ToString());
            Assert.AreEqual('a', cells[1][8]);
            Assert.AreEqual('a', cells[1][16]);
            Assert.AreEqual('a', cells[2][0]);
        }
    }
}

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
            var output = new OutputBuffer()
                .WriteLine("abcd")
                .WriteLine("efgh")
                .WriteLine("ijkl")
                .Render(2, 2);

            Console.WriteLine(Cells.Render(output));

            Assert.AreEqual('a', output[0][0]);
            Assert.AreEqual('b', output[0][1]);
            Assert.AreEqual('e', output[1][0]);
            Assert.AreEqual('f', output[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsNewLineCharacters()
        {
            var output = new OutputBuffer()
                .WriteLine("a" + Environment.NewLine + "b" + Environment.NewLine + "c")
                .Render(2, 2);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[0][0]);
            Assert.AreEqual('b', output[1][0]);
        }

        [TestMethod]
        public void Wrap()
        {
            var output = new OutputBuffer()
                .Wrap("abcdefg")
                .Render(2, 2);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[0][0]);
            Assert.AreEqual('b', output[0][1]);
            Assert.AreEqual('c', output[1][0]);
            Assert.AreEqual('d', output[1][1]);
        }

        [TestMethod]
        public void WrapEndsWithANewLine()
        {
            var output = new OutputBuffer()
                .Wrap("a")
                .Wrap("b")
                .Render(2, 2);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[0][0]);
            Assert.AreEqual('b', output[1][0]);
        }

        [TestMethod]
        public void WrapRespectsNewLineCharacters()
        {
            var output = new OutputBuffer()
                .Wrap("abc" + Environment.NewLine + "defg")
                .Render(2, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a',             output[0][0]);
            Assert.AreEqual('b',             output[0][1]);
            Assert.AreEqual('c',             output[1][0]);
            Assert.AreEqual(Cells.SpaceChar, output[1][1]);
            Assert.AreEqual('d',             output[2][0]);
            Assert.AreEqual('e',             output[2][1]);
        }

        [TestMethod]
        public void WrapRespectsTabCharacters()
        {
            var output = new OutputBuffer()
                .Wrap("1234567890")
                .Wrap("\ta")
                .Render(12, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[1][8]);
        }

        [TestMethod]
        public void Write()
        {
            var output = new OutputBuffer()
                .Write("ab")
                .Render(2, 2);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a',             output[0][0]);
            Assert.AreEqual('b',             output[0][1]);
            Assert.AreEqual(Cells.SpaceChar, output[1][0]);
            Assert.AreEqual(Cells.SpaceChar, output[1][1]);
        }

        [TestMethod]
        public void WriteRespectsNewLineCharacters()
        {
            var output = new OutputBuffer()
                .Write("ab" + Environment.NewLine + "cd")
                .Render(3, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[0][0]);
            Assert.AreEqual('b', output[0][1]);
            Assert.AreEqual('c', output[1][0]);
            Assert.AreEqual('d', output[1][1]);
        }

        [TestMethod]
        public void WriteLineRespectsTabCharacters()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[1][8]);
            Assert.AreEqual('a', output[1][16]);
        }

        [TestMethod]
        public void TabConsidersExistingPosition()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdfe")
                .Write("\ta")
                .Write("ghi")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[1][8]);
            Assert.AreEqual('a', output[1][16]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharactersWithTabSpacesMinusOne()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefgh")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual(Cells.SpaceChar, output[1][7]);
            Assert.AreEqual('a',             output[1][8]);
        }

        [TestMethod]
        public void TabAlwaysHasAtleastOneSpaceBetweenCharacters()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .Write("bcdefghi")
                .Write("\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('i', output[1][7]);
            Assert.AreEqual('a', output[1][16]);
        }

        [TestMethod]
        public void WriteRespectsTabCharacters()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[1][8]);
            Assert.AreEqual('a', output[1][16]);
        }

        [TestMethod]
        public void WriteWrapsTabCharactersToTheNextLine()
        {
            var output = new OutputBuffer()
                .WriteLine("12345678901234567890")
                .WriteLine("\ta\ta\ta")
                .Render(20, 3);
            Console.WriteLine(Cells.Render(output));
            Assert.AreEqual('a', output[1][8]);
            Assert.AreEqual('a', output[1][16]);
            Assert.AreEqual('a', output[2][0]);
        }
    }
}

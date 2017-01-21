namespace Miruken.Mvc.Console.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CellsTests
    {
        [TestMethod]
        public void CanMergeCells()
        {
            var cells = new Cells(5,5);
            var tl    = new Cells(2,2, new Point(0,0), 'a');
            var tr    = new Cells(2,2, new Point(3,0), 'b');
            var bl    = new Cells(2,2, new Point(0,3), 'c');
            var br    = new Cells(2,2, new Point(3,3), 'd');

            for (var y = 0; y < 5; y++)
                cells[y][2] = '|';

            for (var x = 0; x < 5; x++)
                cells[2][x] = '-';

            cells.Merge(tl);
            cells.Merge(tr);
            cells.Merge(bl);
            cells.Merge(br);

            Console.WriteLine(cells.ToString());

            Assert.AreEqual('a', cells[0][0]);
            Assert.AreEqual('a', cells[0][1]);
            Assert.AreEqual('|', cells[0][2]);
            Assert.AreEqual('b', cells[0][3]);
            Assert.AreEqual('b', cells[0][4]);

            Assert.AreEqual('a', cells[1][0]);
            Assert.AreEqual('a', cells[1][1]);
            Assert.AreEqual('|', cells[1][2]);
            Assert.AreEqual('b', cells[1][3]);
            Assert.AreEqual('b', cells[1][4]);

            Assert.AreEqual('-', cells[2][0]);
            Assert.AreEqual('-', cells[2][1]);
            Assert.AreEqual('-', cells[2][2]);
            Assert.AreEqual('-', cells[2][3]);
            Assert.AreEqual('-', cells[2][4]);

            Assert.AreEqual('c', cells[3][0]);
            Assert.AreEqual('c', cells[3][1]);
            Assert.AreEqual('|', cells[3][2]);
            Assert.AreEqual('d', cells[3][3]);
            Assert.AreEqual('d', cells[3][4]);

            Assert.AreEqual('c', cells[4][0]);
            Assert.AreEqual('c', cells[4][1]);
            Assert.AreEqual('|', cells[4][2]);
            Assert.AreEqual('d', cells[4][3]);
            Assert.AreEqual('d', cells[4][4]);
        }
    }
}

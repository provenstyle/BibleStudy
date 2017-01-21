namespace Miruken.Mvc.Console
{
    using System.Text;

    public class Cells
    {
        public const char SpaceChar = ' ';
        public const char NullChar  = (char)0;

        private readonly char[][] _cells;

        public Point Point  { get; set; }
        public int   Height { get;  }
        public int   Width  { get;  }

        public Cells(int height, int width)
            : this (height, width, new Point(0, 0), SpaceChar)
        {
        }

        public Cells(int height, int width, Point point)
            : this (height, width, point, SpaceChar)
        {
        }

        public Cells(int height, int width, Point point, char defaultChar)
        {
            _cells = new char[height][];
            for (var i = 0; i < height; i++)
            {
                _cells[i] = new char[width];
                for (var j = 0; j < width; j++)
                    _cells[i][j] = defaultChar;
            }
            Point  = point;
            Height = height;
            Width  = width;
        }

        public char[] this[int index] => _cells[index];

        public void Merge(Cells cells)
        {
            for (var y = 0; y < cells.Height; y++)
            {
                var targetY = y + cells.Point.Y;
                for (var x = 0; x < cells.Width; x++)
                {
                    var targetX = x + cells.Point.X;
                    _cells[targetY][targetX] = cells[y][x];
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var row in _cells)
                builder.AppendLine(new string(row));
            return builder.ToString();
        }
    }
}
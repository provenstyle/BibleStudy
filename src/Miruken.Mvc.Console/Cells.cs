namespace Miruken.Mvc.Console
{
    using System.Text;

    public class Cells
    {
        public const char SpaceChar = ' ';
        public const char NullChar  = (char)0;

        public static char[][] Create(int height, int width, char defaultChar = SpaceChar)
        {
            var cells = new char[height][];
            for (var i = 0; i < height; i++)
            {
                cells[i] = new char[width];
                for (var j = 0; j < width; j++)
                    cells[i][j] = defaultChar;
            }
            return cells;
        }

        public static string Render(char[][] cells)
        {
            var builder = new StringBuilder();
            foreach (var row in cells)
                builder.AppendLine(new string(row));
            return builder.ToString();
        }
    }
}
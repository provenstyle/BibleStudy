namespace Miruken.Mvc.Console
{
    using Miruken.Mvc.Console;

    public class RenderOutputBuffer
    {
        private const int    tabSpaces = 8;
        private OutputBuffer _outputBuffer;
        private int          _width;
        private int          _height;
        private char[][]     _cells;
        private int          _x;
        private int          _y;

        public char[][] Handle(OutputBuffer outputBuffer, int width, int height)
        {
            _outputBuffer = outputBuffer;
            _width        = width;
            _height       = height;
            _x            = 0;
            _y            = 0;
            _cells        = Cells.Create(_height, _width);

            foreach (var item in _outputBuffer.Outputs)
            {
                switch (item.OutputType)
                {
                    case OutputType.Wrap:
                        Wrap(item);
                        break;
                    case OutputType.Write:
                        Write(item);
                        break;
                    case OutputType.WriteLine:
                        WriteLine(item);
                        break;
                }
                if (_y >= height)
                    break;
            }
            return _cells;
        }

        private void WriteLine(Output item)
        {
            foreach (var t in item.Text)
            {
                switch (t)
                {
                    case '\n':
                        NextLine();
                        break;
                    case '\r':
                        _x = 0;
                        break;
                    case '\t':
                        Tab();
                        break;
                    default:
                        _cells[_y][_x] = t;
                        _x++;
                        break;
                }
                if (_x >= _width || _y >= _height)
                    break;
            }
            NextLine();
        }

        private void Write(Output output)
        {
            foreach (var t in output.Text)
            {
                if (_y >= _height)
                    break;

                switch (t)
                {
                    case '\n':
                        NextLine();
                        break;
                    case '\r':
                        _x = 0;
                        break;
                    case '\t':
                        Tab();
                        break;
                    default:
                        _cells[_y][_x] = t;
                        _x++;
                        break;
                }

                if (_x >= _width)
                    NextLine();
            }
        }

        private void Wrap(Output output)
        {
            Write(output);
            NextLine();
        }

        private void Tab()
        {
            var nextTab = tabSpaces - (_x % tabSpaces);
            if (_x + nextTab > _width)
            {
                _x = 0;
                _y++;
            }
            else
                _x = _x + nextTab;
        }

        private void NextLine()
        {
            _x = 0;
            _y++;
        }
    }
}
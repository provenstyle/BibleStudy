namespace Miruken.Mvc.Console
{
    public class RenderOutputBuffer: Render
    {
        private const int    tabSpaces = 8;
        private OutputBuffer _outputBuffer;
        private int          _x;
        private int          _y;
        private int          _xStart;
        private int          _yStart;
        private int          _xEnd;
        private int          _yEnd;
        private int          _contentWidth;
        private int          _contentHeight;

        public Cells Handle(OutputBuffer outputBuffer, Cells cells)
        {
            _outputBuffer = outputBuffer;
            _cells        = cells;

            if (_outputBuffer.CanRenderBorderAndPadding())
            {
                _xStart        = _outputBuffer.BorderLeft + _outputBuffer.PadLeft;
                _yStart        = _outputBuffer.BorderTop + _outputBuffer.PadTop;
                _contentWidth  = _outputBuffer.Rendered.Width - _outputBuffer.BorderLeft - _outputBuffer.PadLeft - _outputBuffer.PadRight - _outputBuffer.BorderRight;
                _contentHeight = _outputBuffer.Rendered.Height - _outputBuffer.BorderTop - _outputBuffer.PadTop - _outputBuffer.PadBottom - _outputBuffer.BorderBottom;
            }
            else
            {
                _xStart        = 0;
                _yStart        = 0;
                _contentWidth  = _outputBuffer.Rendered.Width;
                _contentHeight = _outputBuffer.Rendered.Height;
            }

            _x    = _xStart;
            _y    = _yStart;
            _xEnd = _xStart + _contentWidth;
            _yEnd = _yStart + _contentHeight;

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
                if (_y >= _yEnd)
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
                if (_x >= _xEnd || _y > _yEnd )
                    break;
            }
            NextLine();
        }

        private void Write(Output output)
        {
            foreach (var t in output.Text)
            {
                if (_y >= _contentHeight)
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

                if (_x >= _contentWidth)
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
            if (_x + nextTab > _contentWidth)
            {
                _x = 0;
                _y++;
            }
            else
                _x = _x + nextTab;
        }

        private void NextLine()
        {
            _x = _xStart;
            _y++;
        }
    }
}
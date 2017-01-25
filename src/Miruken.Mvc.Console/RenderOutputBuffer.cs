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

        public Cells Handle(OutputBuffer outputBuffer, Cells cells)
        {
            _outputBuffer = outputBuffer;
            _cells        = cells;

            int _contentWidth;
            int _contentHeight;

            if (_outputBuffer.CanRenderBorderAndPadding())
            {
                _xStart        = _outputBuffer.Point.X + _outputBuffer.Margin.Left + _outputBuffer.Border.Left + _outputBuffer.Padding.Left;
                _yStart        = _outputBuffer.Point.Y + _outputBuffer.Margin.Top  + _outputBuffer.Border.Top  + _outputBuffer.Padding.Top;
                _contentWidth  = _outputBuffer.ActualSize.Width
                                 - _outputBuffer.Margin.Left  - _outputBuffer.Border.Left  - _outputBuffer.Padding.Left
                                 - _outputBuffer.Margin.Right - _outputBuffer.Border.Right - _outputBuffer.Padding.Right
                                 - _outputBuffer.Point.X;
                _contentHeight = _outputBuffer.ActualSize.Height
                                 - _outputBuffer.Margin.Top    - _outputBuffer.Border.Top     - _outputBuffer.Padding.Top
                                 - _outputBuffer.Margin.Bottom - _outputBuffer.Padding.Bottom - _outputBuffer.Border.Bottom
                                 - _outputBuffer.Point.Y;
            }
            else
            {
                _xStart        = 0;
                _yStart        = 0;
                _contentWidth  = _outputBuffer.ActualSize.Width;
                _contentHeight = _outputBuffer.ActualSize.Height;
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
                        _x = _xStart;
                        break;
                    case '\t':
                        Tab();
                        break;
                    default:
                        _cells[_y][_x] = t;
                        _x++;
                        break;
                }
                if (_x >= _xEnd || _y >= _yEnd )
                    break;
            }
            NextLine();
        }

        private void Write(Output output)
        {
            foreach (var t in output.Text)
            {
                if (_y >= _yEnd)
                    break;

                switch (t)
                {
                    case '\n':
                        NextLine();
                        break;
                    case '\r':
                        _x = _xStart;
                        break;
                    case '\t':
                        Tab();
                        break;
                    default:
                        _cells[_y][_x] = t;
                        _x++;
                        break;
                }

                if (_x >= _xEnd)
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
            if (_x + nextTab > _xEnd)
            {
                _x = _xStart;
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
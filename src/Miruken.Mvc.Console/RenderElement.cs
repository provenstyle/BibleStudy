namespace Miruken.Mvc.Console
{
    public class RenderElement: Render
    {
        private Control  _control;

        public Cells Handle(int width, int height, Control control, Cells output)
        {
            _width   = width;
            _height  = height;
            _control = control;
            _cells   = new Cells(_width, _height);

            RenderOutput(output);

            if (!CanRenderBorderAndPadding())
                return _cells;

            RenderBorder();
            RenderPadding();

            return _cells;
        }

        private bool CanRenderBorderAndPadding()
        {
            return _height >= 3 && _width >= 3;
        }

        private void RenderOutput(Cells output)
        {
            int _contentXStart, _contentYStart, _contentWidth, _contentHeight;

            if (CanRenderBorderAndPadding())
            {
                _contentXStart = _control.BorderLeft + _control.PadLeft;
                _contentYStart = _control.BorderTop  + _control.PadTop;
                _contentWidth  = _width  - _control.BorderLeft - _control.PadLeft - _control.PadRight  - _control.BorderRight;
                _contentHeight = _height - _control.BorderTop  - _control.PadTop  - _control.PadBottom - _control.BorderBottom;
            }
            else
            {
                _contentXStart = 0;
                _contentYStart = 0;
                _contentWidth  = _width;
                _contentHeight = _height;
            }

            for (var y = 0; y < _contentHeight; y++)
                for (var x = 0; x < _contentWidth; x++)
                    _cells[y + _contentYStart][x + _contentXStart] = output[y][x];
        }

        private void RenderPadding()
        {
            RenderPaddingLeft();
            RenderPaddingRight();
            RenderPaddingTop();
            RenderPaddingBottom();
        }

        private void RenderPaddingLeft()
        {
            var xStart = _control.BorderLeft;
            var yStart = _control.BorderTop;
            var height = _height - _control.BorderTop - _control.BorderBottom;
            for (var i = 0; i < _control.PadLeft; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart + i] = Cells.SpaceChar;
        }

        private void RenderPaddingRight()
        {
            var xStart = _width - 1 - _control.BorderRight;
            var yStart = _control.BorderTop;
            var height = _height - _control.BorderTop - _control.BorderBottom;
            for (var i = 0; i < _control.PadRight; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart - i] = Cells.SpaceChar;
        }

        private void RenderPaddingTop()
        {
            var xStart = _control.BorderLeft;
            var yStart = _control.BorderTop;
            var width  = _width - _control.BorderLeft - _control.BorderRight;
            for (var i = 0; i < _control.PadTop; i++)
                for (var x = xStart; x < width; x++)
                    _cells[yStart + i][x] = Cells.SpaceChar;
        }

        private void RenderPaddingBottom()
        {
            var xStart = _control.BorderLeft;
            var yStart = _height - 1 - _control.BorderBottom;
            var width  = _width - _control.BorderLeft - _control.BorderRight;
            for (var i = 0; i < _control.PadBottom; i++)
                for (var x = xStart; x < width; x++)
                    _cells[yStart - i][x] = Cells.SpaceChar;
        }

        private void RenderBorder()
        {
            RenderBorderLeft();
            RenderBorderRight();
            RenderBorderTop();
            RenderBorderBottom();
        }

        private void RenderBorderLeft()
        {
            for (var i = 0; i < _control.BorderLeft; i++)
                for (var y = 0; y < _height; y++)
                    _cells[y][i] =  '|';
        }

        private void RenderBorderRight()
        {
            for (var i = 0; i < _control.BorderRight; i++)
                for (var y = 0; y < _height; y++)
                    _cells[y][_width - 1 - i] = '|';
        }

        private void RenderBorderTop()
        {
            for (var i = 0; i < _control.BorderTop; i++)
                for (var x = 0; x < _width; x++)
                    _cells[i][x] = '-';
        }

        private void RenderBorderBottom()
        {
            for (var i = 0; i < _control.BorderBottom; i++)
                for (var x = 0; x < _width; x++)
                    _cells[_height - 1 -i][x] = '-';
        }
    }
}
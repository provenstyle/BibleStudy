namespace Miruken.Mvc.Console
{
    using Miruken.Mvc.Console;

    public class RenderElement
    {
        private char[][] _cells;
        private Element  _element;
        private int      _width;
        private int      _height;

        public char[][] Handle(int width, int height, Element element, char[][] output)
        {
            _width   = width;
            _height  = height;
            _element = element;
            _cells   = Cells.Create(_width, _height);

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

        private void RenderOutput(char[][] output)
        {
            int _contentXStart, _contentYStart, _contentWidth, _contentHeight;

            if (CanRenderBorderAndPadding())
            {
                _contentXStart = _element.BorderLeft + _element.PadLeft;
                _contentYStart = _element.BorderTop  + _element.PadTop;
                _contentWidth  = _width  - _element.BorderLeft - _element.PadLeft - _element.PadRight  - _element.BorderRight;
                _contentHeight = _height - _element.BorderTop  - _element.PadTop  - _element.PadBottom - _element.BorderBottom;
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
            var xStart = _element.BorderLeft;
            var yStart = _element.BorderTop;
            var height = _height - _element.BorderTop - _element.BorderBottom;
            for (var i = 0; i < _element.PadLeft; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart + i] = Cells.SpaceChar;
        }

        private void RenderPaddingRight()
        {
            var xStart = _width - 1 - _element.BorderRight;
            var yStart = _element.BorderTop;
            var height = _height - _element.BorderTop - _element.BorderBottom;
            for (var i = 0; i < _element.PadRight; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart - i] = Cells.SpaceChar;
        }

        private void RenderPaddingTop()
        {
            var xStart = _element.BorderLeft;
            var yStart = _element.BorderTop;
            var width  = _width - _element.BorderLeft - _element.BorderRight;
            for (var i = 0; i < _element.PadTop; i++)
                for (var x = xStart; x < width; x++)
                    _cells[yStart + i][x] = Cells.SpaceChar;
        }

        private void RenderPaddingBottom()
        {
            var xStart = _element.BorderLeft;
            var yStart = _height - 1 - _element.BorderBottom;
            var width  = _width - _element.BorderLeft - _element.BorderRight;
            for (var i = 0; i < _element.PadBottom; i++)
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
            for (var i = 0; i < _element.BorderLeft; i++)
                for (var y = 0; y < _height; y++)
                    _cells[y][i] =  '|';
        }

        private void RenderBorderRight()
        {
            for (var i = 0; i < _element.BorderRight; i++)
                for (var y = 0; y < _height; y++)
                    _cells[y][_width - 1 - i] = '|';
        }

        private void RenderBorderTop()
        {
            for (var i = 0; i < _element.BorderTop; i++)
                for (var x = 0; x < _width; x++)
                    _cells[i][x] = '-';
        }

        private void RenderBorderBottom()
        {
            for (var i = 0; i < _element.BorderBottom; i++)
                for (var x = 0; x < _width; x++)
                    _cells[_height - 1 -i][x] = '-';
        }
    }
}
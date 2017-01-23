namespace Miruken.Mvc.Console
{
    public class RenderElement: Render
    {
        private   FrameworkElement _element;

        public void Handle(FrameworkElement element, Cells cells)
        {
            _element = element;
            _cells   = cells;

            if (!CanRenderBorderAndPadding()) return;

            RenderBorder();
            RenderPadding();
        }

        private bool CanRenderBorderAndPadding()
        {
            return _element.Rendered.Height >= 3 && _element.Rendered.Width >= 3;
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
            var height = _element.Rendered.Height- _element.BorderTop - _element.BorderBottom;
            for (var i = 0; i < _element.PadLeft; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart + i] = Cells.SpaceChar;
        }

        private void RenderPaddingRight()
        {
            var xStart = _element.Rendered.Width - 1 - _element.BorderRight;
            var yStart = _element.BorderTop;
            var height = _element.Rendered.Height - _element.BorderTop - _element.BorderBottom;
            for (var i = 0; i < _element.PadRight; i++)
                for (var y = yStart; y < height; y++)
                    _cells[y][xStart - i] = Cells.SpaceChar;
        }

        private void RenderPaddingTop()
        {
            var xStart = _element.BorderLeft;
            var yStart = _element.BorderTop;
            var width  = _element.Rendered.Width - _element.BorderLeft - _element.BorderRight;
            for (var i = 0; i < _element.PadTop; i++)
                for (var x = xStart; x < width; x++)
                    _cells[yStart + i][x] = Cells.SpaceChar;
        }

        private void RenderPaddingBottom()
        {
            var xStart = _element.BorderLeft;
            var yStart = _element.Rendered.Height- 1 - _element.BorderBottom;
            var width  = _element.Rendered.Width- _element.BorderLeft - _element.BorderRight;
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
                for (var y = 0; y < _element.Rendered.Height; y++)
                    _cells[y][i] =  '|';
        }

        private void RenderBorderRight()
        {
            for (var i = 0; i < _element.BorderRight; i++)
                for (var y = 0; y < _element.Rendered.Height; y++)
                    _cells[y][_element.Rendered.Width- 1 - i] = '|';
        }

        private void RenderBorderTop()
        {
            for (var i = 0; i < _element.BorderTop; i++)
                for (var x = 0; x < _element.Rendered.Width; x++)
                    _cells[i][x] = '-';
        }

        private void RenderBorderBottom()
        {
            for (var i = 0; i < _element.BorderBottom; i++)
                for (var x = 0; x < _element.Rendered.Width; x++)
                    _cells[_element.Rendered.Height- 1 -i][x] = '-';
        }
    }
}
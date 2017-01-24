namespace Miruken.Mvc.Console
{
    public class RenderElement: Render
    {
        private FrameworkElement _element;

        private Boundry Padding;
        private Boundry Border;

        public void Handle(FrameworkElement element, Cells cells)
        {
            _element = element;
            _cells   = cells;

            if (!CanRenderBorderAndPadding()) return;

            var borderXStart = _element.Point.X;
            var borderYStart = _element.Point.Y;

            var borderXEnd   = borderXStart + _element.ActualSize.Width;
            if (borderXEnd > cells.Width)
                borderXEnd = cells.Width;

            var borderYEnd   = borderYStart + _element.ActualSize.Height;
            if (borderYEnd > cells.Height)
                borderYEnd = cells.Height;

            Border = new Boundry(new Point(borderXStart, borderYStart), new Point(borderXEnd, borderYEnd));

            var paddingXStart = borderXStart + element.PadLeft;
            var paddingYStart = borderYStart + element.PadTop;
            var paddingXEnd   = borderXEnd   - element.PadRight;
            var paddingYEnd   = borderYEnd   - element.PadBottom;

            Padding = new Boundry(new Point(paddingXStart, paddingYStart), new Point(paddingXEnd, paddingYEnd));

            RenderBorder();
            RenderPadding();
        }

        private bool CanRenderBorderAndPadding()
        {
            return _element.ActualSize.Height >= 3 && _element.ActualSize.Width >= 3;
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
            for (var i = 0; i < _element.PadLeft; i++)
                for (var y = Padding.Start.Y; y < Padding.End.Y; y++)
                    _cells[y][Padding.Start.X + i] = Cells.SpaceChar;
        }

        private void RenderPaddingRight()
        {
            for (var i = 0; i < _element.PadRight; i++)
                for (var y = Padding.Start.Y; y < Padding.End.Y; y++)
                    _cells[y][Padding.End.X - 1 - i] = Cells.SpaceChar;
        }

        private void RenderPaddingTop()
        {
            for (var i = 0; i < _element.PadTop; i++)
                for (var x = Padding.Start.X; x < Padding.End.X; x++)
                    _cells[Padding.Start.Y + i][x] = Cells.SpaceChar;
        }

        private void RenderPaddingBottom()
        {
            for (var i = 0; i < _element.PadBottom; i++)
                for (var x = Padding.Start.X; x < Padding.End.X; x++)
                    _cells[Padding.Start.Y - i][x] = Cells.SpaceChar;
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
                for (var y = Border.Start.Y; y < Border.End.Y; y++)
                    _cells[y][i + Border.Start.X] =  '|';
        }

        private void RenderBorderRight()
        {
            for (var i = 0; i < _element.BorderRight; i++)
                for (var y = Border.Start.Y; y < Border.End.Y; y++)
                    _cells[y][Border.End.Y - 1 - i] = '|';
        }

        private void RenderBorderTop()
        {
            for (var i = 0; i < _element.BorderTop; i++)
                for (var x = Border.Start.X; x < Border.End.X; x++)
                    _cells[i + Border.Start.Y][x] = '-';
        }

        private void RenderBorderBottom()
        {
            for (var i = 0; i < _element.BorderBottom; i++)
                for (var x = Border.Start.X; x < Border.End.X; x++)
                    _cells[Border.End.Y - 1 -i][x] = '-';
        }
    }
}
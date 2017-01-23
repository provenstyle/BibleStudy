namespace Miruken.Mvc.Console
{
    using System.Collections.Generic;

    public class OutputBuffer: FrameworkElement
    {
        public List<Output> Outputs { get; set; }

        public OutputBuffer()
        {
            Outputs = new List<Output>();
        }

        public OutputBuffer Write(string text)
        {
            Outputs.Add(new Output(text, OutputType.Write));
            return this;
        }

        public OutputBuffer WriteLine(string text)
        {
            Outputs.Add(new Output(text, OutputType.WriteLine));
            return this;
        }

        public OutputBuffer Wrap(string text)
        {
            Outputs.Add(new Output(text, OutputType.Wrap));
            return this;
        }

        public override void Render(Cells cells)
        {
            base.Render(cells);
            new RenderOutputBuffer()
                .Handle(this, cells);
        }
    }
}
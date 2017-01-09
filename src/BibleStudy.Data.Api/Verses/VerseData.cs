namespace BibleStudy.Data.Api.Verses
{
    using System.Text;
    using Improving.MediatR;

    public class VerseData : Resource<int>
    {
        public int?   BookId  { get; set; }
        public int?   Chapter { get; set; }
        public int?   Number  { get; set; }
        public string Text    { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{BookId} {Chapter}:{Number}");
            builder.AppendLine(Text);

            return builder.ToString();
        }
    }
}
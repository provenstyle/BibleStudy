﻿namespace BibleStudy.Data.Api.Verses
{
    using System.Linq;
    using System.Text;
    using Books;
    using Improving.MediatR;
    using Observations;

    public class VerseData : Resource<int>
    {
        public BookData Book    { get; set; }
        public int?     BookId  { get; set; }
        public int?     Chapter { get; set; }
        public int?     Number  { get; set; }
        public string   Text    { get; set; }

        public ObservationData[] Observations { get; set; }
            = new ObservationData[0];

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Book.Name} {Chapter}:{Number}");
            builder.AppendLine(Text);

            if (Observations.Any())
            {
                builder.AppendLine();
                builder.AppendLine("Observations");
                builder.AppendLine();
                foreach (var observation in Observations)
                    builder.AppendLine($"  {observation.Text}");
            }

            return builder.ToString();
        }
    }
}
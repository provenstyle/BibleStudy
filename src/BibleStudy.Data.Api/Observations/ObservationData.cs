namespace BibleStudy.Data.Api.Observations
{
    using System.Collections.Generic;
    using Improving.MediatR;
    using Verses;

    public class ObservationData : Resource<int>
    {
        public string Text { get; set; }

        public IEnumerable<VerseData> Verses { get; set; } = new List<VerseData>();
    }
}

namespace BibleStudy.Data.Api.Prayers
{
    using System.Collections.Generic;
    using Improving.MediatR;
    using Verses;

    public class PrayerData : Resource<int>
    {
        public string Text { get; set; }

        public IEnumerable<VerseData> Verses { get; set; } = new List<VerseData>();
    }
}
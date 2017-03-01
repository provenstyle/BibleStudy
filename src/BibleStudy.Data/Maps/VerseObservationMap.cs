namespace BibleStudy.Data.Maps
{
    using Entities;

    public class VerseObservationMap : BaseMap<VerseObservation>
    {
        public VerseObservationMap()
        {
            ToTable(nameof(VerseObservation));
        }
    }
}
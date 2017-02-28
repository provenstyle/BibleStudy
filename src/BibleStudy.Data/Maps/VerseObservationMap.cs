namespace BibleStudy.Data.Maps
{
    using Entities;

    public class VerseObservationMap : BaseMap<VerseObservation>
    {
        public VerseObservationMap ObservationMap { get; set; }

        public VerseObservationMap()
        {
            ToTable(nameof(VerseObservation));
        }
    }
}
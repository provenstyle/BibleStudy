namespace BibleStudy.Data.Entities
{
    public class VerseObservation : Entity
    {
        public int VerseId       { get; set; }

        public int ObservationId { get; set; }

        public virtual Verse       Verse       { get; set; }

        public virtual Observation Observation { get; set; }

        public VerseObservation()
        {
        }

        public VerseObservation(Verse verse, Observation observation)
        {
            Verse       = verse;
            Observation = observation;
        }
    }
}
namespace BibleStudy.Data.Entities
{
    public class VersePrayer : Entity
    {
        public int  VerseId  { get; set; }

        public int  PrayerId { get; set; }

        public virtual Verse  Verse  { get; set; }

        public virtual Prayer Prayer { get; set; }
    }
}

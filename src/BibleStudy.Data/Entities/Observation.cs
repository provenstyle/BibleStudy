namespace BibleStudy.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Observation : Entity
    {
        public string Text { get; set; }

        public virtual ICollection<VerseObservation> VerseObservations { get; set; }
            = new HashSet<VerseObservation>();

        public Observation AddVerse(Verse verse)
        {
            var now = DateTime.Now;
            VerseObservations.Add(new VerseObservation
            {
                Verse         = verse,
                VerseId       = verse.Id,
                Observation   = this,
                ObservationId = Id,
                Modified      = now,
            });
            Modified = now;
            return this;
        }

        public Observation RemoveVerseObservation(VerseObservation verseObservation)
        {
            if (VerseObservations.Remove(verseObservation))
                Modified = DateTime.Now;
            return this;
        }
    }
}

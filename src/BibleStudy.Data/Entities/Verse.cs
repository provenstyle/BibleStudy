namespace BibleStudy.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Verse : Entity
    {
        public int    BookId     { get; set; }
        public int    Chapter    { get; set; }
        public int    Number     { get; set; }
        public string Text       { get; set; }

        public virtual Book Book { get; set; }

        public virtual ICollection<VerseObservation> VerseObservations { get; set; }
            = new HashSet<VerseObservation>();

        public Verse AddObservation(Observation observation)
        {
            VerseObservations.Add(new VerseObservation
            {
                Verse         = this,
                VerseId       = Id,
                Observation   = observation,
                ObservationId = observation.Id,
                CreatedBy     = observation.CreatedBy,
                Created       = observation.Created,
                ModifiedBy    = observation.ModifiedBy,
                Modified      = observation.Modified
            });
            Modified = observation.Modified;
            return this;
        }
        public Verse RemoveVerseObservation(VerseObservation verseObservation)
        {
            if (VerseObservations.Remove(verseObservation))
                Modified = DateTime.Now;
            return this;
        }
    }
}

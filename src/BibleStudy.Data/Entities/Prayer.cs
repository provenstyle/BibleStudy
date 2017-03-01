namespace BibleStudy.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Prayer : Entity
    {
        public string Text { get; set; }

        public virtual ICollection<VersePrayer> VersePrayers { get; set; }
            = new HashSet<VersePrayer>();

        public Prayer AddVerse(Verse verse)
        {
            var now = DateTime.Now;
            VersePrayers.Add(new VersePrayer
            {
                Verse    = verse,
                VerseId  = verse.Id,
                Prayer   = this,
                PrayerId = Id,
                Modified = now,
            });
            Modified = now;
            return this;
        }

        public Prayer RemoveVersePrayer(VersePrayer versePrayer)
        {
            if (VersePrayers.Remove(versePrayer))
                Modified = DateTime.Now;
            return this;
        }
    }
}

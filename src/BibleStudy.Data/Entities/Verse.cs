namespace BibleStudy.Data.Entities
{
    using System.Collections.ObjectModel;

    public class Verse : Entity
    {
        public int    BookId     { get; set; }
        public int    Chapter    { get; set; }
        public int    Number     { get; set; }
        public string Text       { get; set; }

        public virtual Book Book { get; set; }

        public virtual Collection<Observation> Observations { get; set; }
    }
}

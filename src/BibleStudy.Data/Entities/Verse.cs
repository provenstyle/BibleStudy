namespace BibleStudy.Data.Entities
{
    public class Verse : Entity
    {
        public int    BookId     { get; set; }
        public int    Chapter    { get; set; }
        public int    Number     { get; set; }
        public string Text       { get; set; }

        public virtual Book Book { get; set; }
    }
}

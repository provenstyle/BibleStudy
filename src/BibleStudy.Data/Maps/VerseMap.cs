namespace BibleStudy.Data.Maps
{
    using Entities;

    public class VerseMap : BaseMap<Verse>
    {
        public VerseMap()
        {
            ToTable(nameof(Verse));
            Property(x => x.Text).HasMaxLength(4000);
        }
    }
}

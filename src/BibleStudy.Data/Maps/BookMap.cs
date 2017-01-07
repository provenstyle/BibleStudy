namespace BibleStudy.Data.Maps
{
    using Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}

namespace BibleStudy.Data.Maps
{
    using Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class TestamentMap : EntityTypeConfiguration<Testament>
    {
        public TestamentMap()
        {
            ToTable(nameof(Testament));
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(3);
        }
    }
}

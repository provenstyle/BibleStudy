namespace BibleStudy.Data.Maps
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Entities;

    public class ObservationMap : EntityTypeConfiguration<Observation>
    {
        public ObservationMap()
        {
            ToTable(nameof(Observation));
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
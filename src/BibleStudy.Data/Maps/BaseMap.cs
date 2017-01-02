namespace BibleStudy.Data.Maps
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Entities;

    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T: Entity
    {
        protected BaseMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        } 
    }
}
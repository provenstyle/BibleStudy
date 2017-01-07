namespace BibleStudy.Data
{
    using System.Data.Entity;
    using BibleStudy.Data.Maps;

    public class MigrationContext : DbContext
    {
        public MigrationContext()
            :base("BibleStudy")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new TestamentMap());
            modelBuilder.Configurations.Add(new VerseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

namespace BibleStudy.Data
{
    using Common.Logging;
    using Highway.Data;

    public class BibleStudyDataContext : DataContext
    {
        public BibleStudyDataContext(string connectionString, IMappingConfiguration mapping) : base(connectionString, mapping)
        {
        }

        public BibleStudyDataContext(string connectionString, IMappingConfiguration mapping, ILog log) : base(connectionString, mapping, log)
        {
        }

        public BibleStudyDataContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration) : base(connectionString, mapping, contextConfiguration)
        {
        }

        public BibleStudyDataContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log) : base(connectionString, mapping, contextConfiguration, log)
        {
        }

        public BibleStudyDataContext(string databaseFirstConnectionString) : base(databaseFirstConnectionString)
        {
        }

        public BibleStudyDataContext(string databaseFirstConnectionString, ILog log) : base(databaseFirstConnectionString, log)
        {
        }
    }
}

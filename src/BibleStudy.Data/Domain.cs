namespace BibleStudy.Data
{
    using System;
    using Highway.Data;
    using Highway.Data.EventManagement.Interfaces;
    using System.Collections.Generic;
    using Common.Logging;
    using Highway.Data.Interceptors.Events;

    public class BibleStudyDomain : IDomain
    {
        public string                ConnectionString { get; }
        public IMappingConfiguration Mappings         { get; }
        public IContextConfiguration Context          { get; }
        public List<IInterceptor>    Events           { get; }
    }

    public class BibleStudyDomainContext : DataContext, IDomainContext<BibleStudyDomain>
    {
        public event EventHandler<BeforeSave> BeforeSave;
        public event EventHandler<AfterSave> AfterSave;

        public BibleStudyDomainContext(string connectionString, IMappingConfiguration mapping) : base(connectionString, mapping)
        {
        }

        public BibleStudyDomainContext(string connectionString, IMappingConfiguration mapping, ILog log) : base(connectionString, mapping, log)
        {
        }

        public BibleStudyDomainContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration) : base(connectionString, mapping, contextConfiguration)
        {
        }

        public BibleStudyDomainContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log) : base(connectionString, mapping, contextConfiguration, log)
        {
        }

        public BibleStudyDomainContext(string databaseFirstConnectionString) : base(databaseFirstConnectionString)
        {
        }

        public BibleStudyDomainContext(string databaseFirstConnectionString, ILog log) : base(databaseFirstConnectionString, log)
        {
        }
    }
}

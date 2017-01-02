namespace BibleStudy.Console
{
    using System;
    using System.Configuration;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Data;
    using Data.Maps;
    using Highway.Data;
    using Highway.Data.Repositories;
    using Improving.MediatR;

    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BibleStudy"].ConnectionString;

            var container = new WindsorContainer();
            container.Install(
                FromAssembly.This(), 
                new MediatRInstaller(Classes.FromAssemblyContaining<BibleStudyDataContext>())
            );

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<MappingConfiguration>(),
                Component.For<IDomainContext<BibleStudyDomain>>().ImplementedBy<BibleStudyDomainContext>().DependsOn(new {connectionString}),
                Component.For<BibleStudyDomain>(),
                Component.For<IDomainRepository<BibleStudyDomain>>().ImplementedBy<DomainRepository<BibleStudyDomain>>()
            );

            var repo = container.Resolve<IDomainRepository<BibleStudyDomain>>();

            Console.ReadKey();
        }
    }
}

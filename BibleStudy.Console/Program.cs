namespace BibleStudy.Console
{
    using System;
    using System.Configuration;
    using System.Linq;
    using Castle.Components.DictionaryAdapter;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Commands;
    using Data;
    using Data.Maps;
    using Highway.Data;
    using Highway.Data.Repositories;
    using Improving.MediatR;
    using Infrastructure;
    using ICommand = Infrastructure.ICommand;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BibleStudy"].ConnectionString;

            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            container.Install(
                FromAssembly.This(),
                new MediatRInstaller(Classes.FromAssemblyContaining<BibleStudyDomainContext>())
            );

            var daf = new DictionaryAdapterFactory();
            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<MappingConfiguration>(),
                Component.For<IDomainContext<BibleStudyDomain>>()
                    .ImplementedBy<BibleStudyDomainContext>()
                    .DependsOn(new {connectionString}),
                Component.For<BibleStudyDomain>(),
                Component.For<IDomainRepository<BibleStudyDomain>>()
                    .ImplementedBy<DomainRepository<BibleStudyDomain>>(),
                Classes.FromThisAssembly()
                    .BasedOn<ICommand>()
                    .OrBasedOn(typeof(IHelp))
                    .WithServiceBase()
                    .WithServiceSelf(),
                 Types.FromThisAssembly()
                     .Where(type => type.IsInterface && type.Name.EndsWith("Config"))
                     .Configure(reg => reg.UsingFactoryMethod(
                        (k, m, c) => daf.GetAdapter(m.Implementation, ConfigurationManager.AppSettings)))
            );

            container.Resolve<Welcome>()
                .Handle(string.Empty).Wait();

            var commands = container.ResolveAll<ICommand>();
            do
            {
                var line = Console.ReadLine();
                var handlers = commands.Where(x => x.CanHandle(line)).ToArray();
                if (handlers.Any())
                {
                    foreach (var handler in handlers)
                    {
                        try
                        {
                            handler.Handle(line).Wait();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Command not recognized: {line}");
                    Console.WriteLine();
                }
            } while (!BaseCommand.Quit);
        }
    }
}

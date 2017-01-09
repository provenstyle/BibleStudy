namespace BibleStudy.Console
{
    using System;
    using System.Configuration;
    using System.Linq;
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

    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BibleStudy"].ConnectionString;

            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            container.Install(
                FromAssembly.This(),
                new MediatRInstaller(Classes.FromAssemblyContaining<BibleStudyDomainContext>())
            );

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<MappingConfiguration>(),
                Component.For<IDomainContext<BibleStudyDomain>>().ImplementedBy<BibleStudyDomainContext>().DependsOn(new {connectionString}),
                Component.For<BibleStudyDomain>(),
                Component.For<IDomainRepository<BibleStudyDomain>>().ImplementedBy<DomainRepository<BibleStudyDomain>>(),
                Classes.FromThisAssembly()
                    .BasedOn<ICommand>()
                    .OrBasedOn(typeof(IHelp))
                    .WithServiceBase()
            );

            var commands = container.ResolveAll<ICommand>();

            new Welcome().Process(string.Empty).Wait();
            do
            {
                var line = Console.ReadLine();
                var handlers = commands.Where(x => x.CanProcess(line)).ToArray();
                if (handlers.Any())
                {
                    foreach (var handler in handlers)
                    {
                        try
                        {
                            handler.Process(line).Wait();
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
                }
            } while (!BaseCommand.Quit);
        }
    }
}

namespace BibleStudy.Console
{
    using System.Configuration;
    using Castle.Components.DictionaryAdapter;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor.Installer;
    using Commands;
    using Data;
    using Data.Maps;
    using Highway.Data;
    using Highway.Data.Repositories;
    using Improving.MediatR;
    using Infrastructure;
    using Miruken.Castle;
    using Miruken.Context;
    using Miruken.Mvc;
    using Miruken.Mvc.Console;
    using ICommand = Infrastructure.ICommand;
    using static Miruken.Protocol;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BibleStudy"].ConnectionString;


            var windsorHandler = new WindsorHandler(container =>
            {
                container.Install(
                    FromAssembly.This(),
                    new MediatRInstaller(Classes.FromAssemblyContaining<BibleStudyDomainContext>()),
                    new ConfigurationFactoryInstaller(Types.FromThisAssembly()),
                    new ResolvingInstaller(Classes.FromThisAssembly())
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
            });

            var appContext = new Context();
            appContext.AddHandlers(windsorHandler, new NavigateHandler(new ViewRegion()));

            P<INavigate>(appContext).Next<WelcomeController>(x =>
               {
                   x.Test();
                   return true;
               });

            while (BaseCommand.Quit != true)
            {
            }

            //container.Resolve<Welcome>()
            //    .Handle(string.Empty).Wait();

            //ICommand[] commands = new ICommand[0];// = container.ResolveAll<ICommand>();
            //do
            //{
            //    var line = Console.ReadLine();
            //    var handlers = commands.Where(x => x.CanHandle(line)).ToArray();
            //    if (handlers.Any())
            //    {
            //        foreach (var handler in handlers)
            //        {
            //            try
            //            {
            //                handler.Handle(line).Wait();
            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine(e);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Command not recognized: {line}");
            //        Console.WriteLine();
            //    }
            //} while (!BaseCommand.Quit);
        }
    }
}

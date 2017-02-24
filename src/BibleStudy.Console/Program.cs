namespace BibleStudy.Console
{
    using System;
    using System.Configuration;
    using Castle.Components.DictionaryAdapter;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor.Installer;
    using Data;
    using Data.Maps;
    using Features.Layout;
    using Highway.Data;
    using Highway.Data.Repositories;
    using Improving.MediatR;
    using Miruken.Castle;
    using Miruken.Context;
    using Miruken.Mvc;
    using Miruken.Mvc.Castle;
    using Miruken.Mvc.Console;
    using static Miruken.Protocol;

    internal class Program
    {
        private static bool Run = true;

        internal static void Quit()
        {
            Run = false;
        }

        private static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BibleStudy"].ConnectionString;

            var windsorHandler = new WindsorHandler(container =>
            {
                container.Install(
                    FromAssembly.This(),
                    new MvcInstaller(Classes.FromThisAssembly()),
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
                     Types.FromThisAssembly()
                         .Where(type => type.IsInterface && type.Name.EndsWith("Config"))
                         .Configure(reg => reg.UsingFactoryMethod(
                            (k, m, c) => daf.GetAdapter(m.Implementation, ConfigurationManager.AppSettings)))
                );
            });

            Console.Title = "Major League Miruken";
            Console.Clear();
            Console.CursorVisible = false;

            var appContext = new Context();
            appContext.AddHandlers(windsorHandler, new NavigateHandler(Window.Region));

            P<INavigate>(appContext).Next<LayoutController>(x =>
            {
                x.ShowLayout();
                return true;
            });

            while (!Window.Quit)
            {
            }
        }
    }
}

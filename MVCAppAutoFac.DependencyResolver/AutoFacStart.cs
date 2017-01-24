using System;
namespace MVCAppAutoFac.DependencyResolver
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using MVCAppAutoFac.BL;

    public static class AutoFacStart
    {
        //private static IContainer Container { get; set; }

        private static ContainerBuilder Builder { get; set; }
        public static ContainerBuilder Start()
        {
            Builder = new ContainerBuilder();
           
            Builder.RegisterModule(new BusinessModule());
         
            return Builder;
        }
    }

    public class BusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Main>().As<IMain>().InstancePerLifetimeScope();
         
            //Bind<IUserInterface>().To<UserInterface>().InRequestScope();
            //Bind<IAd>().To<AD>().InRequestScope();
            //Bind<IMain>().To<Main>().InRequestScope();
            //Bind<IData>().To<Data>().InRequestScope();
            //Bind<IOutput>().To<Output>().InRequestScope();
            //Bind<IReport>().To<Report>().InRequestScope();
        }
    }
}

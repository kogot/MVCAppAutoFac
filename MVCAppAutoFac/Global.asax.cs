using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCAppAutoFac
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Autofac.Core;

    public class Global : HttpApplication
	{
		protected void Application_Start()
		{
		    var builder = MVCAppAutoFac.DependencyResolver.AutoFacStart.Start();

            //// MVC - Register your MVC controllers.
            builder.RegisterControllers(typeof(Global).Assembly);

            //// MVC - OPTIONAL: Register model binders that require DI.
            //builder.RegisterModelBinders(typeof(Global).Assembly);
            //builder.RegisterModelBinderProvider();

            //// MVC - OPTIONAL: Register web abstractions like HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            //// MVC - OPTIONAL: Enable property injection in view pages.
            //builder.RegisterSource(new ViewRegistrationSource());

            //// MVC - OPTIONAL: Enable property injection into action filters.
            //builder.RegisterFilterProvider();

            //// WCF - Register channel factory and channel for service clients.

            //// MVC - Set the dependency resolver to be Autofac.
            var container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

         
            AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
  


        }
	}
}

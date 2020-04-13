using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TableTopLeaderboard.Interfaces.Persistence;
using TableTopLeaderboard.Interfaces.Persistence.Handles;
using TableTopLeaderboard.Interfaces.Services;
using TableTopLeaderboard.Persistence;
using TableTopLeaderboard.Persistence.Handles;
using TableTopLeaderboard.Services;

namespace TableTopLeaderboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(Object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ISqlHandle>(() => new SqlHandle(ConfigurationManager.ConnectionStrings["TableTopLeaderboardDBConn"].ToString()), Lifestyle.Singleton);
            container.Register<IPlayerPersistence, PlayerPersistence>(Lifestyle.Singleton);
            container.Register<IPlayerService, PlayerService>(Lifestyle.Singleton);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}

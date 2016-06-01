using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace MyWeb.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); //注册mvc容器的实现

            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            builder.RegisterAssemblyTypes(assemblys.ToArray()) //查找程序集中以Repository结尾的类型
                .Where(t => t.Name.EndsWith("DAL"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblys.ToArray()) //查找程序集中以Service结尾的类型
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //注册MVC容器
        }
    }
}

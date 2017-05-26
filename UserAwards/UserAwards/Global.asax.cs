using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserAwards.Filters;
using UserAwards.Models;

namespace UserAwards
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			//Database.SetInitializer(new AppDbInitializer());
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			GlobalFilters.Filters.Add(new ActionFilter());
			GlobalFilters.Filters.Add(new ExceptionFilter());
		}
	}
}

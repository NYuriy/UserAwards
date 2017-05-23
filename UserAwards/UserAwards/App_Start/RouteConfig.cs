using System.Web.Mvc;
using System.Web.Routing;

namespace UserAwards
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes();
			
			routes.MapRoute(
			name: "Users",
			url: "users",
			defaults: new { controller = "Person", action = "Index" }
		);

			routes.MapRoute(
			name: "UserDetailsById",
			url: "user/{id}",
			defaults: new { controller = "Person", action = "DetailsById", id = UrlParameter.Optional },
			constraints: new { id = @"[a-f0-9-]+" }
			);

			routes.MapRoute(
			name: "EditUserById",
			url: "user/{id}/edit",
			defaults: new { controller = "Person", action = "EditByUserId", id = UrlParameter.Optional },
			constraints: new { id = @"[a-f0-9-]+" }
			);

			routes.MapRoute(
			name: "DeleteUserById",
			url: "user/{id}/delete",
			defaults: new { controller = "Person", action = "DeleteByUserId", id = UrlParameter.Optional },
			constraints: new { id = @"[a-f0-9-]+" }
			);

			routes.MapRoute(
			name: "UsersContaintsName",
			url: "users/{userName}",
			defaults: new { controller = "Person", action = "IndexContaintsName", userName = UrlParameter.Optional }
			);

			routes.MapRoute(
			name: "UserDetails",
			url: "user/{userName}",
			defaults: new { controller = "Person", action = "UserDetails", userName = UrlParameter.Optional }
			);

			routes.MapRoute(
			name: "ErrorPage",
			url: "ErrorPage/{error}",
			defaults: new { controller = "Error", action = "ErrorPage", error = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Person", action = "Index", id = UrlParameter.Optional }
			);
			

		}
	}
}

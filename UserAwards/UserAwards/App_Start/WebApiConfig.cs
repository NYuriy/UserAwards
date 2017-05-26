using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using System.Web.Mvc;
using Microsoft.Owin.Security.OAuth;

namespace UserAwards
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			//config.MapHttpAttributeRoutes();

			//		config.Routes.MapHttpRoute(
			//name: "test",
			//routeTemplate: "api/users/1",
			//defaults: new { controller = "PersonApi", action = "GetPersonsForLetter", id = RouteParameter.Optional }
			//);

			//		config.Routes.MapHttpRoute(
			//			name: "GetPersonsForLetter",
			//			routeTemplate: "api/users/{id}",
			//			defaults: new { controller = "PersonApi", action = "GetPersonsForLetter", id = RouteParameter.Optional },
			//			constraints: new { id = new LengthRouteConstraint(1) }
			//		);

			//		config.Routes.MapHttpRoute(
			//			name: "GetPersonsForName",
			//			routeTemplate: "api/users/{id}",
			//			defaults: new { controller = "PersonApi", action = "GetPersonsForName", id = RouteParameter.Optional }
			//		);

			//		config.Routes.MapHttpRoute(
			//			name: "GetPersonForId",
			//			routeTemplate: "api/user/{id}",
			//			defaults: new { controller = "PersonApi", action = "GetPersonForId", id = RouteParameter.Optional }
			//		);

			//		config.Routes.MapHttpRoute(
			//			name: "PostCreatePerson",
			//			routeTemplate: "api/user/{id}",
			//			defaults: new { controller = "PersonApi", action = "PostCreatePerson", id = RouteParameter.Optional }
			//		);


			//		config.Routes.MapHttpRoute(
			//					 name: "DefaultApi",
			//					 routeTemplate: "api/{controller}/{id}",
			//					 defaults: new { id = RouteParameter.Optional }
			//				 );


			// Web API routes


			//config.Routes.MapHttpRoute(
			//	name: "test",
			//	routeTemplate: "api/users/{id}",
			//	defaults: new {controller = "PersonApi",
			//		action = "GetPersonsForLetter",
			//		id = UrlParameter.Optional}
			//);

			//config.Routes.MapHttpRoute(
			//	name: "GetPersonsForLetter",
			//	routeTemplate: "api/users/{id}",
			//	defaults: new { controller = "PersonApi", action = "GetPersonsForLetter", id = RouteParameter.Optional },
			//	constraints: new { id = new LengthRouteConstraint(1) }
			//);


			//config.Routes.MapHttpRoute(
			//	name: "DefaultApi1",
			//	routeTemplate: "api/uss/1",
			//	defaults: new { controller = "PersonApi",
			//		action = "GetPersons",
			//		id = RouteParameter.Optional }

			//);

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new {id = RouteParameter.Optional});

			//var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//formatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
		}
	}
}

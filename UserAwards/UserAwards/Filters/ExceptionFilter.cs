using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserAwards.Filters
{
	public class ExceptionFilter: ActionFilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext filterContext)
		{
			
			filterContext.Result = new RedirectToRouteResult("ErrorPage", new RouteValueDictionary(new { error = filterContext.Exception.Message }));
			filterContext.ExceptionHandled = true;
		}
	}
}
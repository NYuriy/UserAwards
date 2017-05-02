using System;
using System.IO;
using System.Threading;
using System.Web.Mvc;

namespace UserAwards.Filters
{
	public class ActionFilter : IActionFilter
	{
		private static object _monitor = new object();

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
				var controller = filterContext.RouteData.Values["controller"];
				var action = filterContext.RouteData.Values["action"];

				Log(string.Format("{0} Start method controller = {1}  action = {2}",
					DateTime.Now.ToLongTimeString(), controller, action));
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
				var controller = filterContext.RouteData.Values["controller"];
				var action = filterContext.RouteData.Values["action"];

				Log(string.Format("{0} Finish method controller = {1}  action = {2}",
					DateTime.Now.ToLongTimeString(), controller, action));
		}

		private void Log(string message)
		{
			string path = @"d:\ControllerActionLog.txt";

			try
			{
				Monitor.Enter(_monitor);
				var writer = new StreamWriter(path, true);
				writer.WriteLine(message);
				writer.Close();
			}
			finally
			{
				Monitor.Exit(_monitor);
			}

		}
	}
}
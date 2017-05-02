using System;
using System.Web.Mvc;

namespace UserAwards.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult TestError()
		{
			throw new Exception("Test Exception");
		}
		
		public ActionResult ErrorPage(string error)
		{
			ViewBag.ErrorMessage = error;
			return View();
		}
	}
}
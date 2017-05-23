using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using UserAwards.Models;

namespace UserAwards.Controllers
{
	public class UserManageController : Controller
	{

		[HttpPost]
		public ActionResult SaveDataUser(List<UserManageModel> list)
		{
			var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

			foreach (var item in list)
			{
				if (item.IsAdmin)
				{
					userManager.AddToRole(item.UserId, "Admin");
				}
				else
				{
					userManager.RemoveFromRole(item.UserId, "Admin");
				}
			}

			return RedirectToAction("Index", "PersonLinkAward");
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Index()
		{
			ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			UserManageModel userManageModel = new UserManageModel();

			var list = userManager.Users.Select(_ => new UserManageModel
			{
				UserId = _.Id,
				UserName = _.Email,
			}).ToList();

			foreach (var user in list)
			{
				user.IsAdmin = userManager.GetRoles(user.UserId).Any(_ => _.Equals("Admin"));
			}
			return View(list);
		}
	}
}
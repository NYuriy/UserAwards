using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAwards.Models;
using UserAwards.Models.Helpers;

namespace UserAwards.Controllers
{
	public class AwardController : Controller
	{

		[Route("awards")]
		public ActionResult AwardsList()
		{
			return View("Index",AwardHelper.AwardModelList);
		}

		[Route("awards/{userName}")]
		public ActionResult IndexByUser(string userName)
		{
			var res = PersonLinkAwardHelper.GetPersonLinkAwardList()
				.Where(_ => _.PersonModelData.Name == userName)
				.Select(_ => _.AwardModelData)
				.ToList();
			return View("Index", res);
		}


		[Route("award/{userId:guid}")]
		public ActionResult AwawrdById(Guid userId)
		{
			return View("Details", AwardHelper.GetAwardModelEntity(userId));
		}

		[Route("award/{id}/edit")]
		public ActionResult EditAward(Guid id)
		{
			return View("Edit", AwardHelper.GetAwardModelEntity(id));
		}

		[Route("award/{id}/delete")]
		public ActionResult DeleteAward(Guid id)
		{
			return View("Delete", AwardHelper.GetAwardModelEntity(id));
		}

		[Route("create-award")]
		public ActionResult CreateAward()
		{
			return View("Create");
		}

		public ActionResult Index()
		{
			return View(AwardHelper.AwardModelList);
		}


		public ActionResult Details(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		public ActionResult Create()
		{
			return View("Create");
		}

		public ActionResult Edit(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		[HttpPost]
		public ActionResult Create(AwardModel model, HttpPostedFileBase image = null)
		{
			try
			{
				if (image != null)
				{
					model.ImageMimeType = image.ContentType;
					model.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(model.ImageData, 0, image.ContentLength);

					ModelState.Remove("ImageData");
					ModelState.Add("ImageData", new ModelState());
					ModelState.SetModelValue("ImageData", new ValueProviderResult(new byte[image.ContentLength], "1", null));
				}


				if (!ModelState.IsValid)
				{
					return View();
				}

				AwardHelper.CreateEntity(model);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(Guid id)
		{
			return View(AwardHelper.GetAwardModelEntity(id));
		}

		public FileContentResult GetImage(Guid id)
		{

			var entity = AwardHelper.GetAwardModelEntity(id);

			if (entity != null && entity.ImageData != null && entity.ImageMimeType != null)
			{
				return File(entity.ImageData, entity.ImageMimeType);
			}

			return null;
		}

		[HttpPost]
		public ActionResult Edit(AwardModel model, HttpPostedFileBase image = null)
		{
			try
			{
				if (image != null)
				{
					model.ImageMimeType = image.ContentType;
					model.ImageData = new byte[image.ContentLength];
					image.InputStream.Read(model.ImageData, 0, image.ContentLength);
				}

				AwardHelper.UpdateEntity(model);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		[HttpPost]
		public ActionResult Delete(AwardModel model)
		{
			try
			{
				AwardHelper.DeleteEntity(model.Id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		
		public ActionResult AwawrdByName(string awardName)
		{
			return View("Details", AwardHelper.AwardModelList.FirstOrDefault(_ => _.Title == awardName));
		}
	}
}

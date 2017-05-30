using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserAwards.Controllers;
using UserAwards.Models.Helpers;

namespace UnitTests
{
	[TestClass]
	public class ValidationUnitTests
	{
		[TestMethod]
		public void ContorllerWillNotEditNoteWithEmptyText()
		{
			var award = AwardHelper.AwardModelList.First();
			award.Title = string.Empty;
			var controller = new AwardController();
			ManualValidation(award, controller);
			controller.Edit(award);
			Assert.IsFalse(controller.ModelState.IsValidField("Title"),"InValid awardModel.title");
		}

		private static bool ManualValidation(object model, Controller controller)
		{
			var validationContex = new ValidationContext(model);
			var validationResults = new List<ValidationResult>();

			var res = Validator.TryValidateObject(model, validationContex, validationResults);

			var results = validationResults.SelectMany(r => r.MemberNames, (r, memberName) => new
			{
				MemberName = memberName,
				r.ErrorMessage
			});
			foreach (var result in results)
			{
				controller.ModelState.AddModelError(result.MemberName, result.ErrorMessage);
			}
			return res;
		}
	}
}

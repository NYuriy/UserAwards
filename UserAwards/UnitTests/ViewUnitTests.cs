using ASP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorGenerator.Testing;
using UserAwards.Models.Helpers;
using HtmlAgilityPack;

namespace UnitTests
{
	[TestClass]
	public class ViewUnitTests
	{
		[TestMethod]
		public void IndexViewTitleTest()
		{
			var view = new _Views_Award_Index_cshtml();
			//view.ViewBag.Title = "IndexAwardTest";
			var html = view.RenderAsHtml(AwardHelper.AwardModelList);
			var awartTitleElement = html.DocumentNode.Element("h2");
			Assert.AreEqual("Index", awartTitleElement.InnerText);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserAwards;

namespace UnitTests
{
	[TestClass]
	public class RouteUnitTest
	{
		[ClassInitialize]
		public static void Init(TestContext contex)
		{
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
		[TestMethod]
		public void RouteEmpty()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~\");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("Index", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RouteEditPerson()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/Person/Edit/7816ec31-2185-4e0f-a32c-64d970eff4d5");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("Edit", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RouteDetailsPerson()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/Person/Details/7816ec31-2185-4e0f-a32c-64d970eff4d5");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("Details", routeData.Values["action"], "Wrong action");
		}


		[TestMethod]
		public void RoutePersons()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/users/");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("Index", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RoutePersonById()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/user/7816ec31-2185-4e0f-a32c-64d970eff4d5");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("DetailsById", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RouteDeleteById()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/user/7816ec31-2185-4e0f-a32c-64d970eff4d5/delete");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("DeleteByUserId", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RouteIndexByName()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/users/Petrov");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("IndexContaintsName", routeData.Values["action"], "Wrong action");
		}

		[TestMethod]
		public void RouteDetailsByName()
		{
			var context = new Mock<HttpContextBase>();
			context.Setup(ctx => ctx.Request.AppRelativeCurrentExecutionFilePath).Returns(@"~/user/Petrov");
			var routeData = RouteTable.Routes.GetRouteData(context.Object);
			Assert.IsNotNull(routeData, "Route not found");
			Assert.AreEqual("Person", routeData.Values["controller"], "Wrong controller");
			Assert.AreEqual("UserDetails", routeData.Values["action"], "Wrong action");
		}
	}
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserAwards.Startup))]
namespace UserAwards
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}

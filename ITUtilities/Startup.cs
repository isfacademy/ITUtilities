using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITUtilities.Startup))]
namespace ITUtilities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

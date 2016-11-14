using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoExploration.Startup))]
namespace PhotoExploration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

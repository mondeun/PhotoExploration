using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(PhotoExploration.Startup))]
namespace PhotoExploration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "AppCookie",
                LoginPath = new PathString("/Account/login")
            });
        }
    }
}

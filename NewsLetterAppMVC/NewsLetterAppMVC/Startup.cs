using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsLetterAppMVC.Startup))]
namespace NewsLetterAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

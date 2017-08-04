using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRiOSignIn.Startup))]
namespace TRiOSignIn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrosBrasInc.Startup))]
namespace GrosBrasInc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

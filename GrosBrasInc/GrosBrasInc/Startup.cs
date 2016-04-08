using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using GrosBrasInc.Models;

[assembly: OwinStartupAttribute(typeof(GrosBrasInc.Startup))]
namespace GrosBrasInc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }
    }
}

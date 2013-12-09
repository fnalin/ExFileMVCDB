using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExFileMVCDB.Startup))]
namespace ExFileMVCDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

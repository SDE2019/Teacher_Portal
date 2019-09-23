using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeacherPortal.Startup))]
namespace TeacherPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

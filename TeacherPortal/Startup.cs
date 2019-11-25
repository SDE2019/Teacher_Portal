using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TeacherPortal.Models;

[assembly: OwinStartupAttribute(typeof(TeacherPortal.Startup))]
namespace TeacherPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@rnsit.com";
                user.Email = "admin@rnsit.com";
                string password = "P@ssw0rd";

                var user1 = userManager.Create(user, password);
                if (user1.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }

            if (!roleManager.RoleExists("faculty"))
            {
                var role = new IdentityRole();
                role.Name = "faculty";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("principal"))
            {
                var role = new IdentityRole();
                role.Name = "principal";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "principal@rnsit.com";
                user.Email = "principal@rnsit.com";
                string password = "P@ssw0rd";

                var user1 = userManager.Create(user, password);
                if (user1.Succeeded)
                {
                    userManager.AddToRole(user.Id, "principal");
                }
            }


        }
    }
}

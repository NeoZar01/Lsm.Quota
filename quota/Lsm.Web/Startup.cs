using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(DoE.Lsm.Web.Startup))]
namespace DoE.Lsm.Web
{
    using Api.Auth;
    using Models;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureCustomAuth();
        }
    }

        public partial class Startup
        {
            public void ConfigureCustomAuth()
            {

                var context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var configRole = new AuthConfig(UserManager, roleManager)
                    .ConfigureRole("Administrators")
                    .ConfigureRole("Subject Specialist")
                    .ConfigureRole("Circuit Manager")
                    .ConfigureRole("Warehouse Manager")
                    .ConfigureRole("SCM Director")
                    .ConfigureRole("EMIS Officer")
                    .ConfigureRole("School");

            }
        }
    
}

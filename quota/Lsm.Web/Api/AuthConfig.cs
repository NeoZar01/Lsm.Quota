/**  
 *   This will run at startup - configuring your users along with roles extending  the default identity classes
 */
///  <summary>
///   This will run at startup - configuring your users along with roles extending b the default identity classes
///   <see> UserManager</see>
///   <seealso>ApplicationUser</seealso>
///   <see> RoleManager</see>
///   <seealso>IdentityRole</seealso>
///  </summary>

using System;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace DoE.Lsm.Web.Api.Auth
{
    using Models;

    //Seal this class to protect it from being inherited.Security reasons.
    public sealed class AuthConfig : IAuthConfig
    {
        // default identity management class   -->User
        private UserManager<ApplicationUser> _userManager;

        // default identity management class   -->Role
        private RoleManager<IdentityRole> _roleManager;

        private string normalPassword = ConfigurationManager.AppSettings["NormalUserPassword"];
        private string powerPassword  = ConfigurationManager.AppSettings["Power.UserPassword"];

        public AuthConfig(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

     // This method will configure your roles
        /// <summary>
        ///   This method will configure your roles
        /// </summary>
        public IAuthConfig ConfigureRole(string roleName)
        {
            if (!_roleManager.RoleExists(roleName))  //This will run as a callback function.If the roles does not exist, continue checking if this is an administration role or create the role.
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = roleName;
                _roleManager.Create(role);
            }
            return roleName.Equals("Administrators") ? ConfigureUser(ConfigurationManager.AppSettings["Usern.Admin"], roleName) : this; 
        }

    // This method will configure your users
        ///  <summary>
        ///      This method will configure your users
        ///   <param name="userName"></param>
        ///   <param name="role"></param>
        ///  </summary>

        public IAuthConfig ConfigureUser(string userName, string role)
        {
            var user = new ApplicationUser();
                user.UserName = userName;

            if (userName.Equals(ConfigurationManager.AppSettings["Usern.Admin"]))
            {
                user.Email       = ConfigurationManager.AppSettings["Inq.Admin.Email"];
                user.PhoneNumber = ConfigurationManager.AppSettings["Inq.Tel"];
                normalPassword   = powerPassword;
            }
                user.EmailConfirmed = false;
                user.LockoutEnabled = false;

            var createUserTask = _userManager.Create(user, normalPassword);
            if (createUserTask.Succeeded)
            {
                var result1 = _userManager.AddToRole(user.Id, role);
            }

            return this;
        }
    }
}
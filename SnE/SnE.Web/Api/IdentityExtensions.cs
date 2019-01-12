using System;
using System.Web;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace DoE.Lsm.Web.Api
{
    using Annotations;

    /// <summary>
    ///  <para> Creates extension methods for the default Identity framework.</para>    
    /// 
    ///  <see cref="Microsoft.AspNet.Identity"/>
    /// </summary>
    public static class IdentityExtensions
    {

        /// <summary>
        ///     Gets firstname
        /// </summary>
        /// <see cref="IIdentity"/>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }

        /// <summary>
        ///      Gets surname
        /// </summary>
        ///  <see cref="IIdentity"/>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetSurname(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Surname");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }

        /// <summary>
        ///     Gets maiden name
        /// </summary>
        ///  <see cref="IIdentity"/>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Name");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }

        /// <summary>
        ///         Checks if the current session is an impersonation.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static bool IsImpersonating(this IPrincipal  principal)
        {
            var claimPrincipal = principal as ClaimsPrincipal;

            if (claimPrincipal == null) throw new ArgumentNullException(nameof(principal));

            return claimPrincipal.HasClaim("UserImpersonation", "true");
        }


        /// <summary>
        ///     Get the Entity Type
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EntityType");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }

        /// <summary>
        ///     Get Global Identity Token from the Profile Store
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetToken(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Token");

            return (claim != null) ? string.IsNullOrEmpty(claim.Value) ? " " : claim.Value : " ";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetImpersonator(this IPrincipal principal)
        {
            var claimsPrincipal = principal as ClaimsPrincipal;

            if (claimsPrincipal == null) throw new ArgumentNullException(nameof(principal));


            if (!claimsPrincipal.IsImpersonating())
            {
                return string.Empty;
            }

            var originalUsernameClaim = claimsPrincipal.Claims.SingleOrDefault(c => c.Type == "impersonator");

            if (originalUsernameClaim == null)
            {
                return String.Empty;
            }

            return originalUsernameClaim.Value;
        }

        /// <summary>
        ///       Allow administrator to impersonate users.
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="impersonator"></param>
        /// <param name="impersonatee"></param>
        /// <param name="_userManager"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async static Task<SignInStatus> ImpersonationSignInAsync(this ApplicationSignInManager signInManager, string impersonator, string impersonatee, ApplicationUserManager _userManager, HttpContext context)
        {

            try
            {
                var impersonatedUser = await _userManager.FindByNameAsync(impersonatee);

                var impersonatedIdentity = await impersonatedUser.GenerateUserIdentityAsync(_userManager);
                impersonatedIdentity.AddClaim(new Claim("UserImpersonation", "true"));
                impersonatedIdentity.AddClaim(new Claim("impersonator", impersonator));

                var authenticationManager = context.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);

                return SignInStatus.Success;
            }
            catch
            {
                return SignInStatus.Failure;
            }
        }

    }
}
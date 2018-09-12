using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DoE.Lsm.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Name", string.IsNullOrEmpty(this.Name) ? " " : this.Name));

            userIdentity.AddClaim(new Claim("FirstName", string.IsNullOrEmpty(this.FirstName) ? " " : this.FirstName));

            userIdentity.AddClaim(new Claim("Surname", string.IsNullOrEmpty(this.Surname) ? " " : this.Surname));

            userIdentity.AddClaim(new Claim("Token", string.IsNullOrEmpty(this.Token) ? " " : this.Token));

            userIdentity.AddClaim(new Claim("EntityType", string.IsNullOrEmpty(this.EntityType) ? " " : this.EntityType));

            return userIdentity;
        }

        public string Name
        { get; set; }

        public string FirstName
        { get; set; }

        public string Surname
        { get; set; }

        public string Token
        { get; set; }

        public string EntityType
        { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
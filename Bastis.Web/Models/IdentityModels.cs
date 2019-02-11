using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bastis.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<CustomPermission> CustomPermissions { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }




        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }

        //public DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<CustomPermission> CustomPermissions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<State> States { get; set; }






        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //ublic System.Data.Entity.DbSet<Bastis.Models.Entities.State> States { get; set; }
        public System.Data.Entity.DbSet<ApplicationRole> IdentityRoles { get; set; }
    }
}
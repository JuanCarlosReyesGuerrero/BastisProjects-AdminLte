﻿using Bastis.Models.Entities;
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
        public virtual ICollection<CustomPermission> CustomPermissions { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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


        //public DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CustomPermission> CustomPermissions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Photo> Photos { get; set; }


        public DbSet<Prueba> Pruebas { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomPermission>()
                .HasRequired(n => n.ApplicationUser)
                .WithMany(a => a.CustomPermissions)
                .HasForeignKey(n => n.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
              .HasRequired(n => n.ApplicationRole)
              .WithMany(a => a.Permissions)
              .HasForeignKey(n => n.ApplicationRoleId)
              .WillCascadeOnDelete(false);



            //modelBuilder.Entity<CustomPermission>()
            //   .HasRequired(c => c.ApplicationUser)
            //   .WithMany(t => t.CustomPermissions)
            //   .Map(m => m.MapKey("ApplicationUserId"));
        }



        //ublic System.Data.Entity.DbSet<Bastis.Models.Entities.State> States { get; set; }
        public System.Data.Entity.DbSet<ApplicationRole> IdentityRoles { get; set; }

    }
}
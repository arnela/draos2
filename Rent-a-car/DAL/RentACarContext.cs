using Microsoft.AspNet.Identity.EntityFramework;
using Rent_a_car.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Rent_a_car.DAL
{
    public class RentACarContext : IdentityDbContext<ApplicationUser>
    {
        public RentACarContext() : base("RentACarContext") { }

        public DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<IdentityUserClaim> Claims { get; set; }
        public DbSet<IdentityUserLogin> Logins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static RentACarContext Create()

        {
            return new RentACarContext();
        }
    }
}
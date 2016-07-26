using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Model.Models;

namespace XepHang.Data
{
    public class XepHangDbContext : IdentityDbContext<ApplicationUser>
    {
        public XepHangDbContext() : base("XepHangDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        //public static XepHangDbContext Create()
        //{
        //    return new XepHangDbContext();
        //}

        public DbSet<Department> Departments { set; get; }
        public DbSet<NumberReport> NumberReports { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Error> Errors { set; get; }

        public static XepHangDbContext Create()
        {
            return new XepHangDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            //builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            //builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            //builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}

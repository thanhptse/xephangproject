namespace XepHang.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XepHang.Data.XepHangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XepHangDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new XepHangDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new XepHangDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "thanhpt",
                Email = "thanhptse@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Phan Trung Thanh"

            };

            manager.Create(user, "123abc$#");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
                roleManager.Create(new IdentityRole { Name = "Doctor" });
            }

            var adminUser = manager.FindByEmail("thanhptse@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User", "Doctor" });
        }
    }
}

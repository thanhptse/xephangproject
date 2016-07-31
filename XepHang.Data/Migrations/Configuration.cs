namespace XepHang.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XepHangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XepHangDbContext context)
        {
            CreateDepartmentSample(context);
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new XepHangDbContext()));

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new XepHangDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "thanhpt",
                Email = "thanhptse@gmail.com",
                EmailConfirmed = true,
                //BirthDay = DateTime.Now,
                FullName = "Phan Trung Thành"

            };

            manager.Create(user, "123456");

            if (!rolemanager.Roles.Any())
            {
                rolemanager.Create(new IdentityRole { Name = "Admin" });
                rolemanager.Create(new IdentityRole { Name = "User" });
                rolemanager.Create(new IdentityRole { Name = "Doctor" });
            }

            var adminuser = manager.FindByEmail("thanhptse@gmail.com");

            manager.AddToRoles(adminuser.Id, new string[] { "Admin", "User", "Doctor" });
        }

        private void CreateDepartmentSample(XepHangDbContext context)
        {
            if (context.Departments.Count() == 0)
            {
                List<Department> listDepartment = new List<Department>()
                {
                     new Department() {DepartmentName="Da Liễu",CreatedDate=DateTime.Now,Status=true },
                    new Department() {DepartmentName="Nhi",CreatedDate=DateTime.Now,Status=true },
                    new Department() {DepartmentName="Răng Hàm Mặt",CreatedDate=DateTime.Now,Status=true },
                    new Department() {DepartmentName="Phụ Sản",CreatedDate=DateTime.Now,Status=true },

                };

                context.Departments.AddRange(listDepartment);
                context.SaveChanges();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XepHang.Model.Models;
using XepHang.Web.Models;

namespace XepHang.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDepartment(this Department department, DepartmentViewModel departmentVM)
        {
            department.DepeartmentId = departmentVM.DepeartmentId;
            department.DepeartmentName = departmentVM.DepeartmentName;

            department.CreatedDate = departmentVM.CreatedDate;
            department.CreateBy = departmentVM.CreateBy;
            department.ModifiledDate = departmentVM.ModifiledDate;
            department.ModifiledBy = departmentVM.ModifiledBy;
            department.Status = departmentVM.Status;
        }
    }
}
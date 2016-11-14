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
            department.DepartmentId = departmentVM.DepartmentId;
            department.DepartmentName = departmentVM.DepartmentName;

            department.CreatedDate = departmentVM.CreatedDate;
            department.Note = departmentVM.Note;
            department.CreateBy = departmentVM.CreateBy;
            department.ModifiledDate = departmentVM.ModifiledDate;
            department.ModifiledBy = departmentVM.ModifiledBy;
            department.Status = departmentVM.Status;
        }

        public static void UpdateRoom(this Room room, RoomViewModel roomVM)
        {
            room.RoomId = roomVM.RoomId;
            room.RoomName = roomVM.RoomName;
            room.DepartmentId = roomVM.DepartmentId;

            room.CreatedDate = roomVM.CreatedDate;
            room.Note = roomVM.Note;
            room.CreateBy = roomVM.CreateBy;
            room.ModifiledDate = roomVM.ModifiledDate;
            room.ModifiledBy = roomVM.ModifiledBy;
            room.Status = roomVM.Status;
        }

        public static void UpdateOrder(this Order order, OrderViewModel orderVM)
        {
            order.OrderId = orderVM.OrderId;
            order.Username = orderVM.Username;
            order.OrderDate = orderVM.OrderDate;
            order.RoomId = orderVM.RoomId;
            //order.ChosenNumber = orderVM.ChosenNumber;
            order.Username = orderVM.Username;

            order.ModifiledDate = orderVM.ModifiledDate;
            order.ModifiledBy = orderVM.ModifiledBy;
            order.Status = orderVM.Status;
        }

        public static void UpdateNumberreport(this NumberReport report, NumberReportViewModel reportVM)
        {
            report.Id = reportVM.Id;
            report.RoomId = reportVM.RoomId;
            report.CurrentNumbebOrder = reportVM.CurrentNumbebOrder;
            report.TotalNumberOrder = reportVM.TotalNumberOrder;
            
        }
    }
}
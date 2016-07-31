using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XepHang.Model.Models;
using XepHang.Web.Models;

namespace XepHang.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Department, DepartmentViewModel>();
            Mapper.CreateMap<Room, RoomViewModel>();
            Mapper.CreateMap<Order, OrderViewModel>();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Data.Infrastructure;
using XepHang.Model.Models;

namespace XepHang.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
    }
}
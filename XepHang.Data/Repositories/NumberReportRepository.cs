using System;
using System.Linq;
using System.Collections.Generic;
using XepHang.Data.Infrastructure;
using XepHang.Model.Models;
namespace XepHang.Data.Repositories
{
    public interface INumberReportRepository : IRepository<NumberReport>
    {
        IQueryable<NumberReport> GetByRoomAndDate(int roomId);
    }
    public class NumberReportRepository : RepositoryBase<NumberReport>, INumberReportRepository
    {
        public NumberReportRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<NumberReport> GetByRoomAndDate(int roomId)
        {
            //linq to sql from join on
            var query = from p in DbContext.NumberReports
                        where p.RoomId == roomId
                        select p;
            query.Single();
            return query;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Data.Infrastructure;

namespace XepHang.Data.Repositories
{
    public interface INumberReportRepository : IRepository<NumberReport>
    {

    }
    public class NumberReport : RepositoryBase<NumberReport>, INumberReportRepository
    {
        public NumberReport(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

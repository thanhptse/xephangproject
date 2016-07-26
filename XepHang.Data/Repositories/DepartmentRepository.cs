using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Data.Infrastructure;
using XepHang.Model.Models;

namespace XepHang.Data.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetByName(string name);
    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public IEnumerable<Department> GetByName(string name)
        {
            return DbContext.Departments.Where(x => x.DepeartmentName == name);
        }
    }
}

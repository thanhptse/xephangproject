using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private XepHangDbContext dbContext;

        public XepHangDbContext Init()
        {
            return dbContext ?? (dbContext = new XepHangDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}

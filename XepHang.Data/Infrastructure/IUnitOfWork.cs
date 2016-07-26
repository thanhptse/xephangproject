using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XepHang.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}

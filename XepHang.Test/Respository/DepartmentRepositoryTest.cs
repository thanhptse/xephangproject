using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XepHang.Data.Infrastructure;
using XepHang.Data.Repositories;
using XepHang.Model.Models;

namespace XepHang.Test.Respository
{
    [TestClass]
    public class DepartmentRepositoryTest
    {
        IDbFactory dbFactory;
        IDepartmentRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new DepartmentRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Department_Repository_Create()
        {
            Department department = new Department();
            department.DepeartmentName = "Da liễu";
            department.CreateBy = "thanhpt";
            department.CreatedDate = DateTime.Now;
            department.Status = true;

            var result = objRepository.Add(department);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.DepeartmentId);
        }

        [TestMethod]
        public void Department_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(4, list.Count);
        }
    }
}

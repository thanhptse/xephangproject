using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XepHang.Data.Repositories;
using XepHang.Data.Infrastructure;
using XepHang.Service;
using XepHang.Model.Models;
using System.Collections.Generic;

namespace XepHang.Test.ServiceTest
{
    [TestClass]
    public class DepartmentServiceTest
    {
        private Mock<IDepartmentRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IDepartmentService _departmentService;
        private List<Department> _listDepartment;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IDepartmentRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _departmentService = new DepartmentService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listDepartment = new List<Department>
            {
                new Department() {DepeartmentId=1,DepeartmentName="Xin chao", CreatedDate=DateTime.Now,Status=true },
                new Department() {DepeartmentId=2,DepeartmentName="Xin hi", CreatedDate=DateTime.Now,Status=true },
                new Department() {DepeartmentId=3,DepeartmentName="Xin chao hi", CreatedDate=DateTime.Now,Status=true },
            };
        }

        [TestMethod]
        public void Department_Service_GetAll()
        {
            // setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listDepartment);
            // goi phuong thuc
            var result = _departmentService.GetAll() as List<Department>;

            //so sanh
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void Department_Service_Create()
        {
            Department department = new Department();
            department.DepeartmentName = "Da liễu";
            department.CreateBy = "thanhpt";
            department.CreatedDate = DateTime.Now;
            department.Status = true;

            _mockRepository.Setup(m => m.Add(department)).Returns((Department d) =>
            {
                d.DepeartmentId = 1;
                return d;
            });

            var result = _departmentService.Add(department);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.DepeartmentId);
        }
    }
}
